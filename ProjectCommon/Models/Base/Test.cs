using ProjectCommon.ViewModelBase;

namespace ProjectCommon.Models.Base
{
    public class Test : ViewModel
    {
        private int moistureSoilTestId;
        private string materialName;
        private Customer customerTest;
        private string dateTest;
        private string documentTest;

        /// <summary>
        /// Id в базе данных.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Порядковый номер теста (протокола).
        /// </summary>
        public int MoistureSoilTestId
        {
            get => moistureSoilTestId;
            set => Set(ref moistureSoilTestId, value);
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
        public int CustomerTestId { get; set; }

        /// <summary>
        /// Навигационное свойство для Customer.
        /// </summary>
        public Customer CustomerTest
        {
            get => customerTest;
            set => Set(ref customerTest, value);
        }

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

        public virtual void Calculate()
        {

        }
    }
}
