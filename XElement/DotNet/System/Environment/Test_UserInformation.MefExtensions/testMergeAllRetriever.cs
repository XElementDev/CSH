using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace XElement.DotNet.System.Environment.UserInformation.MefExtensions
{
    [TestClass]
    public class testMergeAllRetriever
    {
        [TestMethod]
        public void testMergeAllRetriever_IsExportedViaMef()
        {
            var mefHelper = new testMergeAllRetriever.MefHelper();
            var container = this.CreateMefContainer();
            container.ComposeParts( mefHelper );

            Assert.IsNotNull( mefHelper.UserInformation );
        }



        private CompositionContainer CreateMefContainer()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var path = Path.GetDirectoryName( assembly.Location );
            var catalog = new DirectoryCatalog( path );
            var container = new CompositionContainer( catalog );
            return container;
        }



        [Export]
        private class MefHelper
        {
            [Import]
            public IUserInformation UserInformation { get; private set; }
        }
    }
}
