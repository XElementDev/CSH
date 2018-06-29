using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.AccessControl;
using Telerik.JustMock;
using XElement.DotNet.System.Environment.UserInformation;
using XeRandom = XElement.TestUtils.Random;

namespace XElement.CloudSyncHelper.Logic.Execution.MkLink
{
    [TestClass]
    public class testExecutor_NonAdmin
    {
        [ClassInitialize]
        public static void ClassInitialize( TestContext testContext )
        {
            IRoleInformation roleInfoMock = Mock.Create<IRoleInformation>();
            Mock.Arrange( () => roleInfoMock.Role ).Returns( Role.User );
            IRoleInfoRetriever retrieverMock = Mock.Create<IRoleInfoRetriever>();
            Mock.Arrange( () => retrieverMock.Get() ).Returns( roleInfoMock );
            testExecutor_NonAdmin._dependencies = new DependenciesDTO
            {
                RoleInfoRetriever = retrieverMock
            };

            return;
        }



        [TestMethod]
        [ExpectedException( typeof( PrivilegeNotHeldException ) )]
        public void testExecutor_Execute_ThrowsExceptionIfNotInAdminMode__RandomValues()
        {
            var possibleTypes = new[] { Type.DIRECTORY_LINK, Type.FILE_LINK };
            var randomType = XeRandom.RandomTFromArrayOf( possibleTypes );
            var parameters = new ParametersDTO
            {
                Link = "irrelevant link folder path",
                Target = "irrelevant target folder path",
                Type = randomType
            };
            IExecutor target = CreateInstance( parameters );

            target.Execute();
        }



        private static IExecutor CreateInstance( ParametersDTO parameters )
        {
            return new Executor( parameters, testExecutor_NonAdmin._dependencies );
        }


        private static DependenciesDTO _dependencies;
    }
}
