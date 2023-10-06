namespace PackageSenderExam
{
    public partial class Form1 : Form

    {
        enum PackageType
        {
            pocztowka,
            list,
            paczka
        }
        string street = "";
        string city = "";
        string postalCode = "";
        PackageType packageType = PackageType.pocztowka;
        public Form1()
        {
            InitializeComponent();
        }

        private void pocztowka_CheckedChanged(object sender, EventArgs e)
        {
            packageType = PackageType.pocztowka;
        }

        private void list_CheckedChanged(object sender, EventArgs e)
        {
            packageType = PackageType.list;
        }

        private void paczka_CheckedChanged(object sender, EventArgs e)
        {
            packageType = PackageType.paczka;
        }

        private void checkPriceBtn_Click(object sender, EventArgs e)
        {
            var price = "";
            switch (packageType)
            {
                   case PackageType.pocztowka:
                    price = "1.0";
                    break;
                case PackageType.list:
                    price= "1.5";
                    break;
                case PackageType.paczka:
                    price= "10.0";
                    break;
            }
            priceView.Text = "Cena: "+price+ "zł";
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if(postalCode.Length!=5)
            {
                MessageBox.Show("Nieprawidłowa liczba cyfr w kodzie pocztowym");
            }
            else if(postalCode.Any(x=> char.IsLetter(x)))
            {
                MessageBox.Show("Kod pocztowy powinien się składać z samych cyfr");
            }
            else
            {
                MessageBox.Show("Dane przesyłki zostały wprowadzone");
            }

        }

        private void streetInput_TextChanged(object sender, EventArgs e)
        {
            street = streetInput.Text;
        }

        private void postalCodeInput_TextChanged(object sender, EventArgs e)
        {
            postalCode = postalCodeInput.Text;
        }

        private void cityInput_TextChanged(object sender, EventArgs e)
        {
            city = cityInput.Text;
        }
    }
}