using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Telerik.JustMock;
using XElement.CloudSyncHelper.ReparsePointAdapter;
using XElement.DotNet.System.Environment.UserInformation;

namespace XElement.CloudSyncHelper.Logic.Execution.MkLink
{
    [TestClass]
    public class testExecutor_Admin
    {
        [ClassInitialize]
        public static void ClassInitialize( TestContext testContext )
        {
            IRoleInformation roleInformation = new WindowsPrincipalRetriever().Get();
            var currentRole = roleInformation.Role ?? Role.User;
            if ( currentRole != Role.Administrator )
            {
                Assert.Inconclusive( "Admin rights are required to run this test class." );
            }

            IRoleInformation roleInfoMock = Mock.Create<IRoleInformation>();
            Mock.Arrange( () => roleInfoMock.Role ).Returns( Role.Administrator );
            IRoleInfoRetriever retrieverMock = Mock.Create<IRoleInfoRetriever>();
            Mock.Arrange( () => retrieverMock.Get() ).Returns( roleInfoMock );
            testExecutor_Admin._dependencies = new DependenciesDTO
            {
                RoleInfoRetriever = retrieverMock
            };

            return;
        }



        [TestMethod]
        public void testExecutor_Execute__FolderLinkRestRandomValues()
        {
            using ( TempCreateFolder tempLinkFolder = new TempCreateFolder(),
                                     tempTargetFolder = new TempCreateFolder() )
            {
                Directory.Delete( tempLinkFolder.FolderPath );
                var parameters = new ParametersDTO
                {
                    Link = tempLinkFolder.FolderPath, 
                    Target = tempTargetFolder.FolderPath, 
                    Type = Type.DIRECTORY_LINK
                };
                IExecutor target = CreateInstance( parameters );

                target.Execute();

                var linkPointingTo = new ReparsePointHelper().GetTarget( tempLinkFolder.FolderPath );
                Assert.AreEqual( tempTargetFolder.FolderPath, linkPointingTo );
            }
        }

        [TestMethod]
        public void testExecutor_Execute__FileLinkRestRandomValues()
        {
            using ( TempCreateFile tempLinkFile = new TempCreateFile(),
                                   tempTargetFile = new TempCreateFile() )
            {
                File.Delete( tempLinkFile.FilePath );
                var parameters = new ParametersDTO
                {
                    Link = tempLinkFile.FilePath,
                    Target = tempTargetFile.FilePath,
                    Type = Type.FILE_LINK
                };
                IExecutor target = CreateInstance( parameters );

                target.Execute();

                var linkPointingTo = new ReparsePointHelper().GetTarget( tempLinkFile.FilePath );
                Assert.AreEqual( tempTargetFile.FilePath, linkPointingTo );
            }
        }

        [TestMethod]
        public void testExecutor_Execute_CanHandleWhitespaceInPaths__FolderLinkRestRandomValues()
        {
            using ( TempCreateFolder tempLinkFolder = new TempCreateFolder( "has some space" ),
                                     tempTargetFolder = new TempCreateFolder( "other whitespace" ) )
            {
                Directory.Delete( tempLinkFolder.FolderPath );
                var parameters = new ParametersDTO
                {
                    Link = tempLinkFolder.FolderPath,
                    Target = tempTargetFolder.FolderPath,
                    Type = Type.DIRECTORY_LINK
                };
                IExecutor target = CreateInstance( parameters );

                target.Execute();

                var linkPointingTo = new ReparsePointHelper().GetTarget( tempLinkFolder.FolderPath );
                Assert.AreEqual( tempTargetFolder.FolderPath, linkPointingTo );
            }
        }

        [TestMethod]
        public void testExecutor_Execute_CanHandleWhitespaceInPaths__FileLinkRestRandomValues()
        {
            using ( TempCreateFile tempLinkFile = new TempCreateFile( "link file" ),
                                   tempTargetFile = new TempCreateFile( "target file" ) )
            {
                File.Delete( tempLinkFile.FilePath );
                var parameters = new ParametersDTO
                {
                    Link = tempLinkFile.FilePath,
                    Target = tempTargetFile.FilePath,
                    Type = Type.FILE_LINK
                };
                IExecutor target = CreateInstance( parameters );

                target.Execute();

                var linkPointingTo = new ReparsePointHelper().GetTarget( tempLinkFile.FilePath );
                Assert.AreEqual( tempTargetFile.FilePath, linkPointingTo );
            }
        }



        private static IExecutor CreateInstance( ParametersDTO parameters )
        {
            return new Executor( parameters, testExecutor_Admin._dependencies );
        }


        private static DependenciesDTO _dependencies;
    }
}
