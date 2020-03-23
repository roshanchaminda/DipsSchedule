using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DipsSchedule.DataStore;
using DipsSchedule.Enums;
using DipsSchedule.Models;
using DipsSchedule.Services;
using Moq;
using Xunit;

namespace DipsSchedule.UnitTests.Services
{
    public class ScheduleServiceTests
    {
        private readonly Mock<IScheduleDataStore> _scheduleDataStoreMock = new Mock<IScheduleDataStore>();

        private readonly Mock<IDateTimeProvider> _dateTimeProviderMock = new Mock<IDateTimeProvider>();

        private readonly IScheduleService _scheduleService;

        public ScheduleServiceTests()
        {
            _scheduleService = new ScheduleService(_scheduleDataStoreMock.Object, _dateTimeProviderMock.Object);
        }

        public async void GetAllSchedules_DataStoreEmpty_ReturnEmptySet()
        {
            _scheduleDataStoreMock.Setup(scheduleDataStore => scheduleDataStore.GetItemsAsync())
                .Returns(Task.FromResult((IEnumerable<ScheduleDetail>)new List<ScheduleDetail>()));

            var actual = await _scheduleService.GetAllSchedules();

            Assert.Empty(actual);
        }

        [Fact]
        public async void GetAllSchedules_DataStoreHasThreeItems_ReturnListOfThree()
        {
            _scheduleDataStoreMock.Setup(scheduleDataStore => scheduleDataStore.GetItemsAsync())
                .Returns(Task.FromResult((IEnumerable<ScheduleDetail>)GetScheduleDetails(3)));

            var actual = await _scheduleService.GetAllSchedules();

            Assert.Equal(3, actual.Count);
        }

        [Fact]
        public async void GetAllSchedules_DataStoreReturnNull_ReturnEmptyList()
        {
            _scheduleDataStoreMock.Setup(scheduleDataStore => scheduleDataStore.GetItemsAsync())
                .Returns(Task.FromResult((IEnumerable<ScheduleDetail>)null));

            var actual = await _scheduleService.GetAllSchedules();

            Assert.Empty(actual);
        }

        [Fact]
        public async void GetAllSchedules_Default_InvokesDataStore()
        {
            await _scheduleService.GetAllSchedules();

            _scheduleDataStoreMock.Verify(scheduleDataStoreMock => scheduleDataStoreMock.GetItemsAsync());
        }

        [Fact]
        public async void GetScheduleItem_Default_ReturnItem()
        {
            _scheduleDataStoreMock.Setup(scheduleDataStore => scheduleDataStore.GetItemAsync(It.IsAny<int>())).Returns(Task.FromResult(GetScheduleDetail()));

            var result = await _scheduleService.GetScheduleItem(203023);

            Assert.Equal(123123, result.ScheduleId);
        }

        [Fact]
        public async void GetCurrentWeekData_Default_ReturnDatesInWeek()
        {
            var expected = new DateTime(2020, 03, 5);
            _dateTimeProviderMock.SetupGet(dateTimeProvider => dateTimeProvider.Now).Returns(expected);

            var result = await _scheduleService.GetCurrentWeekData();

            Assert.Equal(expected.AddDays(-3), result[0].DateValue);
            Assert.Equal(expected.AddDays(-3).Day, result[0].DateValue.Day);

        }

        private static List<ScheduleDetail> GetScheduleDetails(int count)
        {
            var scheduleDetailList = new List<ScheduleDetail>();
            for (var i = 0; i < count; i++)
            {
                scheduleDetailList.Add(new ScheduleDetail
                {
                    ScheduleDetailId = 1,
                    UserInfo = GetUser(),
                    ScheduleDate = DateTime.Now.AddDays(-3),
                    ScheduleCategory = ScheduleCategory.Category1,
                    ScheduleTime = "15.00 - 15.30",
                    ReferenceDetail = "Referred by Dr. David Campbell",
                    UserStatus = ScheduleUserStatus.CheckedIn,
                    Diagnosis = "Chest Pain",
                    ContactType = "Treatment",
                    DiagnosisGroup = "Other cardiothoracic procedures",
                    HealthIssue = "Chest pain",
                    TentativeDiagnosis = "acute pericarditis",
                    ReferralReason = "Complains about chest pain over period of two weeks",
                    LevelOfCare = "Outpatient",
                    RoomNumber = "35",
                    UserAppointments = new List<UserAppointments>()
                });
            }

            return scheduleDetailList;
        }

        private static ScheduleDetail GetScheduleDetail()
        {
            var scheduleDetail = new ScheduleDetail()
            {
                ScheduleDetailId = 123123,
                UserInfo = GetUser(),
                ScheduleDate = DateTime.Now.AddDays(-3),
                ScheduleCategory = ScheduleCategory.Category1,
                ScheduleTime = "15.00 - 15.30",
                ReferenceDetail = "Referred by Dr. David Campbell",
                UserStatus = ScheduleUserStatus.CheckedIn,
                Diagnosis = "Chest Pain",
                ContactType = "Treatment",
                DiagnosisGroup = "Other cardiothoracic procedures",
                HealthIssue = "Chest pain",
                TentativeDiagnosis = "acute pericarditis",
                ReferralReason = "Complains about chest pain over period of two weeks",
                LevelOfCare = "Outpatient",
                RoomNumber = "35",
                UserAppointments = new List<UserAppointments>()
            };

            return scheduleDetail;
        }


        private static User GetUser()
        {
            return new User()
            {
                UserId = 1,
                ContactNumber = "",
                Email = "",
                FirstName = "",
                LastName = "",
                Gender = "",
                ReferenceNumber = "",
                RegisteredDate = DateTime.Now,
                Surname = ""
            };
        }
    }
}
