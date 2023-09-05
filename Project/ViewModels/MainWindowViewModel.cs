using Project.Views.Pages.SelectPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Project.ViewModels.Base;
using System.Windows.Input;
using Project.ViewModels.Comands;

namespace Project.ViewModels
{

    internal class MainWindowViewModel : ViewModel
    {
        #region Enum
        enum SelectNewTaskEnum
        {
            NewTest,
            LoadTest
        }

        enum SelectTypeTestEnum
        {
            Soil,
            Sand,
            Geotextile,
            Gravel,
            SandAndGravel
        }

        #endregion
        
        #region Commands

        public ICommand SelectNewTaskCommand { get; }
        private bool CanSelectNewTaskCommandExecute(object p) => true;
        private void OnSelectNewTaskCommandExecuted(object p)
        {
          int task = (int)p;

            switch (task)
            {
                case (int)SelectNewTaskEnum.NewTest:
                    FramePage = SelectTypeTest;
                    break;
                case (int)SelectNewTaskEnum.LoadTest:

                    break;
            }
                          
        }

        public ICommand SelectTypeTestCommand { get; }
        private bool CanSelectTypeTestCommandExecute(object p) => true;

        private void OnSelectTypeTestCommandExecuted(object p)
        {
            int task = (int)p;

            switch (task)
            {
                case (int)SelectTypeTestEnum.Soil:
                    
                    break;
                case (int)SelectTypeTestEnum.Sand:

                    break;
                case (int)SelectTypeTestEnum.Gravel:

                    break;
                case (int)SelectTypeTestEnum.SandAndGravel:

                    break;
                case (int)SelectTypeTestEnum.Geotextile:

                    break;
            }

        }


        #endregion

        #region Page

        private Page framePage;
        private Page selectNewTask;
        private Page selectTypeTest;

        public Page FramePage
        {
            get => framePage;
            set => Set(ref framePage, value);
        }
        public Page SelectNewTask
        {
            get
            {
                if (selectNewTask == null)
                {
                    selectNewTask = new SelectNewTask();
                    selectNewTask.DataContext = this;
                }

                return selectNewTask;
            }

            set => Set(ref selectNewTask, value);
        }
        public Page SelectTypeTest
        {
            get
            {
                if (selectTypeTest == null)
                {
                    selectTypeTest = new SelectTypeTest();
                    selectTypeTest.DataContext = this;
                }

                return selectTypeTest;
            }

            set => Set(ref selectTypeTest, value);
        }
        
        #endregion



        public MainWindowViewModel()
        {
            FramePage = SelectNewTask;
 
            SelectNewTaskCommand = new LambdaCommand(OnSelectNewTaskCommandExecuted, CanSelectNewTaskCommandExecute);
        }
    }


}
