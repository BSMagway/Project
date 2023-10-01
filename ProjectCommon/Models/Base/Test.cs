using ProjectCommon.Enums;
using ProjectCommon.ViewModelBase;

namespace ProjectCommon.Models.Base
{
    public class Test : ViewModel
    {
        private int testNumber;
        private string materialName;
        private string dateTest;
        private string documentTest;

        /// <summary>
        /// Id в базе данных.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Порядковый номер теста (протокола).
        /// </summary>
        public int TestNumber
        {
            get => testNumber;
            set => Set(ref testNumber, value);
        }

        /// <summary>
        /// Название испытываемого материала.
        /// </summary>
        public string MaterialName
        {
            get => materialName;
            set => Set(ref materialName, value);
        }
        /// <summary>
        /// Заказчик испытания.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Навигационное свойство для Customer.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Дата проведения испытания.
        /// </summary>
        public string DateTest
        {
            get => dateTest;
            set => Set(ref dateTest, value);
        }

        /// <summary>
        /// Нормативная документация на испытание.
        /// </summary>
        public string DocumentTest
        {
            get => documentTest;
            set => Set(ref documentTest, value);
        }

        public MaterialType MaterialEnum { get; set; }

        public ExperimentType TestEnum { get; set; }

        public virtual void Calculate()
        {

        }
    }
}
