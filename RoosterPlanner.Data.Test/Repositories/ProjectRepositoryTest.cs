using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RoosterPlanner.Common;
using RoosterPlanner.Data.Context;
using RoosterPlanner.Models;

namespace RoosterPlanner.Data.Repositories
{
    [TestClass]
    public class ProjectRepositoryTest : DatabaseContext
    {
        private Project CreateProjectObject(Guid id, string name = null)
        {
            Project project = new Project {
                Id = id,
                Name = name ?? $"Project_{DateTime.Now.ToString("yyyyddMM-HHmm")}",
                StartDate = DateTime.Today.AddDays(-7),
                LastEditBy = "System",
                LastEditDate = DateTime.UtcNow.Date
            };
            return project;
        }

        [ClassInitialize()]
        public static void ClassInit(TestContext context) => Init(context);

        [TestMethod]
        public void Can_Add_New_Entity()
        {
            //Arrange
            Project project = new Project {
                Name = $"Project_{DateTime.Now.ToString("yyyyddMM-HHmm")}",
                StartDate = DateTime.Today.AddDays(-7),
                LastEditBy = "System",
                LastEditDate = DateTime.UtcNow.Date
            };

            MockRepository mockRepo = new MockRepository(MockBehavior.Default);
            Mock<ILogger> loggerMock = mockRepo.Create<ILogger>();

            //Act
            Project addedProject = null;
            Project savedProject = null;
            using (RoosterPlannerContext context = GetRoosterPlannerContext(connectionStringsConfig))
            {
                ProjectRepository projectRepo = new ProjectRepository(context, loggerMock.Object);
                addedProject = projectRepo.AddOrUpdate(project);

                context.SaveChanges();
            }

            using (RoosterPlannerContext context = GetRoosterPlannerContext(connectionStringsConfig))
            {
                savedProject = context.Projects.Find(addedProject.Id);
            }

            //Assert
            Assert.IsNotNull(addedProject);
            Assert.IsNotNull(savedProject);
            Assert.AreNotEqual<Guid>(Guid.Empty, addedProject.Id);
            Assert.AreEqual<Guid>(addedProject.Id, savedProject.Id);
        }

        [TestMethod]
        public void Can_Get_Entity_ByKey()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
