using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace English_
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = String.Format("О программе Learning_English");
            labelProductName.Text = "Название продукта: приложение «Learning_English»";
            labelVersion.Text = "Версия 1.1.0";
            labelCopyright.Text = "Разработала: Никитина А.В. (29ТП)";
            labelCompanyName.Text = "Минский Государственный колледж электроники";
            textBoxDescription.Text = "Приветствуем Вас в приложении, которое поможет вам изучить грамматические темы по английскому языку! Для начала раюоты с программой пройдите авторизацию, выберите тренировочный модуль, пройдите обучение и проверьте свои знания посредствам контрольного тестирования, каждый успешно изученый модуль прибавит вам знаний и увеличит Ваш уровень!";

        }

        #region Методы доступа к атрибутам сборки

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {
            labelProductName.Text = "Название продукта: приложение «Learning_English»";
            labelVersion.Text = "Версия 1.1.0";
            labelCopyright.Text = "Разработала: Никитина А.В. (29ТП)";
            labelCompanyName.Text = "Минский Государственный колледж электроники";
            textBoxDescription.Text = "Приветствуем Вас в приложении, которое поможет вам изучить грамматические темы по английскому языку! Для начала раюоты с программой пройдите авторизацию, выберите тренировочный модуль, пройдите обучение и проверьте свои знания посредствам контрольного тестирования, каждый успешно изученый модуль прибавит вам знаний и увеличит Ваш уровень!";
        }
    }
}
