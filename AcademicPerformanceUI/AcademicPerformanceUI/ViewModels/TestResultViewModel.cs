﻿using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class TestResultViewModel:BaseViewModel<TestResult>
    {
        private ObservableCollection<TestResult> _TestResults;
        private TestResult _SelectedTestResult;
        public ObservableCollection<Guid> StudentIds { get; set; }
        public ObservableCollection<Guid> TestIds { get; set; }

        public TestResultViewModel()
        {
            _SelectedTestResult = new TestResult();
            LoadData();
        }

        public TestResult SelectedTestResult
        {
            get => _SelectedTestResult;
            set => SetProperty(ref _SelectedTestResult, value);
        }

        public ObservableCollection<TestResult> TestResults
        {
            get => _TestResults;
            set => SetProperty(ref _TestResults, value);
        }

        public void LoadData()
        {
            _TestResults = new ObservableCollection<TestResult>(InMemory.TestResults);
            TestIds = new ObservableCollection<Guid>(InMemory.Tests.Select(o => o.Id));
            StudentIds = new ObservableCollection<Guid>(InMemory.Students.Select(o => o.Id));
        }

        public void AddData()
        {
            var newTestResult = new TestResult()
            {
                Id = Guid.NewGuid(),
                Mark = SelectedTestResult.Mark,
                StudentId = SelectedTestResult.StudentId,
                TestId = SelectedTestResult.TestId
            };
            InMemory.TestResults.Add(newTestResult);
            TestResults.Add(newTestResult);
            var x = TestResults;
        }

        public void RemoveData()
        {
            InMemory.TestResults = InMemory.TestResults
                                            .Where(x => x.Id != _SelectedTestResult.Id)
                                            .ToList();
            TestResults.Remove(SelectedTestResult);
            SelectedTestResult = new TestResult();
        }

        public void UpdateData()
        {
            var data = InMemory.TestResults.Find(o => o.Id == SelectedTestResult.Id);
            data = new TestResult()
            {
                Id = _SelectedTestResult.Id,
                Mark = SelectedTestResult.Mark,
                StudentId = SelectedTestResult.StudentId,
                TestId = SelectedTestResult.TestId
            };
            var x = TestResults.ToList().Find(o => o.Id == SelectedTestResult.Id);
            x = data;
        }
    }
}
