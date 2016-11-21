using System;
using System.Collections.Generic;
using System.Windows.Input;
using Students.Model;

namespace Students.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly Storage _storage = new Storage();
        private Student _selectedStudent = new Student();
        private bool _isFilter = false;
        private List<Student> _students;

        public ICommand FilterCommand { get; set; }
        public ICommand CleanFilterCommand { get; set; }
        public ICommand CreateStudentCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }
        public ICommand RemoveStudentCommand { get; set; }

        public Group SelectedFilterGroup { get; set; }
        public string SelectedFilterCity { get; set; } = "";
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                if (value == null) _selectedStudent = new Student();
                else _selectedStudent = new Student
                {
                    StudentId = value.StudentId,
                    BirthDate = value.BirthDate,
                    BirthPlace = value.BirthPlace,
                    FirstName = value.FirstName,
                    RowVersion = value.RowVersion,
                    GroupId = value.GroupId,
                    IndexNo = value.IndexNo,
                    LastName = value.LastName,
                };
                OnPropertyChanged();
            }
        }

        public List<Student> Students
        {
            get {
                return _students;
            }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public void SetStudents()
        {
            Students = IsFilter ? _storage.Filter(
                                    SelectedFilterGroup.GroupId,
                                    SelectedFilterCity.ToLower())
                                : _storage.GetStudents();
        }
        public bool IsFilter {
            get
            {
                return _isFilter;
            }
            set
            {
                _isFilter = value;
                OnPropertyChanged();
                SetStudents();
            }
        }

        public List<Group> FilterGroups {
            get
            {
                var groups = _storage.GetGroups();
                groups.Insert(0, new Group());
                return groups;
            }

        }
        public List<Group> Groups => _storage.GetGroups();

        public bool IsCreateUpdate
        {
            get
            {
                if (SelectedStudent.StudentId != 0)
                    return !_students.Find(s => s.StudentId == SelectedStudent.StudentId)
                              .Equals(SelectedStudent);
                else
                    return !SelectedStudent.Equals(new Student());
            }
        }


        public void CreateStudent()
        {
            this._storage.CreateStudent(SelectedStudent);
            SelectedStudent = new Student();
            SetStudents();
        }

        public void RemoveStudent()
        {
            this._storage.RemoveStudent(SelectedStudent);
            SelectedStudent = new Student();
            SetStudents();
        }

        public void UpdateStudent()
        {
            this._storage.UpdateStudent(SelectedStudent);
            SelectedStudent = new Student();
            SetStudents();
        }
        
        public void FilterStudents()
        {
            IsFilter = true;
        }

        public void CleanFilter()
        {
            IsFilter = false;
            SelectedFilterCity = "";
            SelectedFilterGroup = FilterGroups[0];
            OnPropertyChanged(nameof(SelectedFilterCity));
            OnPropertyChanged(nameof(SelectedFilterGroup));
        }

        public MainWindowViewModel()
        {
            CreateStudentCommand = new RelayCommand<string>(
                param => this.CreateStudent(),
                param => IsCreateUpdate);
            RemoveStudentCommand = new RelayCommand<string>(
                param => this.RemoveStudent(),
                param => SelectedStudent.StudentId != 0);
            UpdateStudentCommand = new RelayCommand<string>(
                param => this.UpdateStudent(),
                param => IsCreateUpdate);
            FilterCommand = new RelayCommand<string>(
                param => this.FilterStudents());
            CleanFilterCommand = new RelayCommand<string>(
                param => this.CleanFilter(),
                param => IsFilter);

            SelectedFilterGroup = FilterGroups[0];
            Students = _storage.GetStudents();
        }
    }
}