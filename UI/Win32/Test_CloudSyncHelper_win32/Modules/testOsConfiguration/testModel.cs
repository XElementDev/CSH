using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Telerik.JustMock;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XeRandom = XElement.TestUtils.Random;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
    [TestClass]
    public class testModel
    {
        [TestInitialize()]
        public void TestInitialize()
        {
            this.ResetParameters();
        }


        [TestCleanup()]
        public void TestCleanup()
        {
            this.ResetParameters();
        }



        [TestMethod]
        public void testOsConfigurationModel_Constructor_InitializesMoveToCloudCommand()
        {
            this.InitializeTarget();

            Assert.IsNotNull( this._target.MoveToCloudCommand );
            Assert.IsInstanceOfType( this._target.MoveToCloudCommand, typeof( ICommand ) );
        }


        [TestMethod]
        public void testOsConfigurationModel_MoveToCloudCommand_CanExecute_NegativeCase1()
        {
            this._isInCloudReturnValue = true;
            this._isInstalledValue = true;
            this._isSuitableForOsReturnValue = true;
            this.InitializeTarget();

            var condition = this._target.MoveToCloudCommand.CanExecute( "irrelevant" );

            Assert.IsFalse( condition );
        }

        [TestMethod]
        public void testOsConfigurationModel_MoveToCloudCommand_CanExecute_NegativeCase2()
        {
            this._isInCloudReturnValue = false;
            this._isInstalledValue = false;
            this._isSuitableForOsReturnValue = true;
            this.InitializeTarget();

            var condition = this._target.MoveToCloudCommand.CanExecute( "irrelevant" );

            Assert.IsFalse( condition );
        }

        [TestMethod]
        public void testOsConfigurationModel_MoveToCloudCommand_CanExecute_NegativeCase3()
        {
            this._isInCloudReturnValue = false;
            this._isInstalledValue = true;
            this._isSuitableForOsReturnValue = false;
            this.InitializeTarget();

            var condition = this._target.MoveToCloudCommand.CanExecute( "irrelevant" );

            Assert.IsFalse( condition );
        }

        [TestMethod]
        public void testOsConfigurationModel_MoveToCloudCommand_CanExecute_NegativeCase4__RandomValues()
        {
            Action falsifyIsInCloudReturnValue = () => this._isInCloudReturnValue = true;
            Action falsifyIsInstalledValue = () => this._isInstalledValue = false;
            Action falsifyIsSuitableForOsReturnValue = () => this._isSuitableForOsReturnValue = false;
            var toExecute = XeRandom.RandomTFromArrayOf( falsifyIsInCloudReturnValue, 
                                                         falsifyIsInstalledValue, 
                                                         falsifyIsSuitableForOsReturnValue );
            toExecute();
            this.InitializeTarget();

            var condition = this._target.MoveToCloudCommand.CanExecute( "irrelevant" );

            Assert.IsFalse( condition );
        }

        [TestMethod]
        public void testOsConfigurationModel_MoveToCloudCommand_CanExecute_PositiveCase()
        {
            this._isInCloudReturnValue = false;
            this._isInstalledValue = true;
            this._isSuitableForOsReturnValue = true;
            this.InitializeTarget();

            var condition = this._target.MoveToCloudCommand.CanExecute( "irrelevant" );

            Assert.IsTrue( condition );
        }


        [TestMethod]
        public void testOsConfigurationModel_MoveToCloudCommand_Execute_CallsLogic()
        {
            Mock.Arrange( () => this._osConfigurationMock.MoveToCloud() ).MustBeCalled();
            this.InitializeTarget();

            this._target.MoveToCloudCommand.Execute( "irrelevant" );

            Mock.Assert( this._osConfigurationMock );
        }

        [TestMethod]
        public void testOsConfigurationModel_MoveToCloudCommand_Execute_RaisesPropertyChangedEvents()
        {
            var expectedEventsRaised = new Dictionary<string, bool>();
            this.InitializeTarget();
            this._target.LinkCommand.CanExecuteChanged += 
                ( s, e ) => expectedEventsRaised[nameof( this._target.LinkCommand )] = true;
            this._target.MoveToCloudCommand.CanExecuteChanged += 
                ( s, e ) => expectedEventsRaised[nameof( this._target.MoveToCloudCommand )] = true;
            this._target.PropertyChanged += ( s, e ) =>
            {
                var isInCloudProp = nameof( this._target.IsInCloud );
                if ( e.PropertyName == isInCloudProp )
                    expectedEventsRaised[isInCloudProp] = true;
            };
            Assert.IsTrue( expectedEventsRaised.All( kvp => kvp.Value == false ) );

            this._target.MoveToCloudCommand.Execute( "irrelevant" );

            Assert.AreEqual( 3, expectedEventsRaised.Count );
            Assert.IsTrue( expectedEventsRaised.All( kvp => kvp.Value == true ) );
        }

        [TestMethod]
        public void testOsConfigurationModel_MoveToCloudCommand_Execute_RaisesPropertyChangedEventsInCorrectOrder()
        {
            var logic = "logic";
            var buttonEvent = "buttonEvent";
            var propertyEvent = "propertyEvent";
            var executionOrder = new List<string>();
            Mock.Arrange( () => this._osConfigurationMock.MoveToCloud() )
                .DoInstead( () => executionOrder.Add( logic ) );
            this.InitializeTarget();
            this._target.LinkCommand.CanExecuteChanged += 
                ( s, e ) => executionOrder.Add( buttonEvent );
            this._target.MoveToCloudCommand.CanExecuteChanged += 
                ( s, e ) => executionOrder.Add( buttonEvent );
            this._target.PropertyChanged += ( s, e ) => executionOrder.Add( propertyEvent );

            this._target.MoveToCloudCommand.Execute( "irrelevant" );

            Assert.AreEqual( logic, executionOrder.First() );
            Assert.AreEqual( propertyEvent, executionOrder.ElementAt( 1 ) );
        }



        private IOsChecker CreateOsCheckerMock()
        {
            var osCheckerMock = Mock.Create<IOsChecker>();
            Mock.Arrange( () => osCheckerMock.IsSuitableForOs( null ) ).IgnoreArguments()
                .Returns( this._isSuitableForOsReturnValue );
            return osCheckerMock;
        }


        private IFactory<IOsConfiguration, Win32.Model.IOsConfigurationParameters> 
            CreateOsConfigFactoryMock()
        {
            Mock.Arrange( () => this._osConfigurationMock.IsInCloud )
                .Returns( this._isInCloudReturnValue );
            var osConfigurationFactoryMock = Mock.Create<IFactory<IOsConfiguration, 
                                                         Win32.Model.IOsConfigurationParameters>>();
            Mock.Arrange( () => osConfigurationFactoryMock.Get( null ) ).IgnoreArguments()
                .Returns( this._osConfigurationMock );
            return osConfigurationFactoryMock;
        }


        private void InitializeTarget()
        {
            var parameters = new ModelParametersDTO
            {
                ApplicationInfo = Arg.IsAny<IApplicationInfo>(), 
                IsInstalled = this._isInstalledValue, 
                OsConfigurationInfo = Mock.Create<IOsConfigurationInfo>()
            };

            var dependencies = new ModelDependenciesDTO
            {
                LinkFactory = null,
                OsConfigurationFactory = this.CreateOsConfigFactoryMock(),
                OsChecker = this.CreateOsCheckerMock()
            };
            this._target = new Model( parameters, dependencies );
        }


        private void ResetParameters()
        {
            this._target = null;
            this._isInCloudReturnValue = XeRandom.RandomBool();
            this._isInstalledValue = XeRandom.RandomBool();
            this._isSuitableForOsReturnValue = XeRandom.RandomBool();
            this._osConfigurationMock = Mock.Create<IOsConfiguration>();
        }



        private bool _isInCloudReturnValue;
        private bool _isInstalledValue;
        private bool _isSuitableForOsReturnValue;
        private IOsConfiguration _osConfigurationMock;
        private Model _target;
    }
}
