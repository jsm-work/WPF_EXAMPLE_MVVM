using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_SAMPLE.ViewModel
{
    //(INotifyPropertyChanged notifies the View of property changes, so that Bindings are updated.)
    // INotifyPropertyChanged는 바인딩이 업데이트되도록 속성 변경 사항을 View에 통지한다. 
    sealed class VM_User : INotifyPropertyChanged
    {
        private Model.M_User user;

        /// <summary>
        /// 이름
        /// </summary>
        public string FirstName
        {
            get { return user.FirstName; }
            set
            {
                if (user.FirstName != value)
                {
                    user.FirstName = value;
                    OnPropertyChange("FirstName");
                    // 이름이 변경된 경우 FullName 값에 영향을 주므로 Change 이벤트 실행
                    OnPropertyChange("FullName");
                }
            }
        }

        /// <summary>
        /// 성
        /// </summary>
        public string LastName
        {
            get { return user.LastName; }
            set
            {
                if (user.LastName != value)
                {
                    user.LastName = value;
                    OnPropertyChange("LastName");
                    // If the first name has changed, the FullName property needs to be udpated as well.
                    OnPropertyChange("FullName");
                }
            }
        }

        /// <summary>
        /// 이 속성은 모델 특성을 뷰에 다르게 표시할 수 있는 방법의 예다. 
        /// 이 경우 생년월일을 사용자 연령으로 변환하여 읽기만 한다.
        /// </summary>
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - user.BirthDate.Year;
                if (user.BirthDate > today.AddYears(-age)) age--;
                return age;
            }
        }

        /// <summary>
        /// (이름 + 성)으로 반환한다.
        /// </summary>
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public VM_User()
        {
            user = new Model.M_User
            {
                FirstName = "Taylor",
                LastName = "Swift",
                BirthDate = DateTime.Now.AddYears(-32)
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
