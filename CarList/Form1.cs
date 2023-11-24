using System.Diagnostics;

namespace CarList
{
    public partial class Form1 : Form
    {
        static int selectedCarId = -1;
        private ListViewColumnSorter lvwColumnSorter;

        static bool isEditing = false;
        public Form1()
        {
            InitializeComponent();
            var CLV = carListView;
            CLV.View = View.Details;

            CLV.AllowColumnReorder = true;
            CLV.FullRowSelect = true;
            CLV.GridLines = true;
            CLV.Sorting = SortOrder.Ascending;

            CLV.HeaderStyle = ColumnHeaderStyle.Clickable;
            List<Car> cars = Database.getCars();

            Debug.WriteLine(cars.Count);


            CLV.Columns.Add("ID", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("Marka", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("Model", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("Rok produkcji", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("Przebieg (km)", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("Poj. silnika (CC)", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("Moc silnika", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("Kolor", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("Rodzaj paliwa", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("Skrzynia biegów", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("Typ nadwozia", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("Kraj pochodzenia", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("VIN", -2, HorizontalAlignment.Left);
            CLV.Columns.Add("Cena (zł)", -2, HorizontalAlignment.Left);





            ListViewItem[] listViewItems = new ListViewItem[cars.Count];
            cars.ForEach(car =>
            {
                Debug.WriteLine(car.Id);
                listViewItems[cars.IndexOf(car)] = new ListViewItem(new string[] { car.Id.ToString(), car.Make, car.Model, car.YearOfProduction.ToString(), car.Mileage.ToString(), car.EngineCapacity.ToString(), car.EnginePower.ToString(), car.Color, car.FuelType, car.Gearbox, car.BodyType, car.CountryOfOrigin, car.VIN, (((double)car.Price) / 100).ToString() });
            }
            );
            CLV.Items.AddRange(listViewItems);
            lvwColumnSorter = new ListViewColumnSorter();
            CLV.ListViewItemSorter = lvwColumnSorter;
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = SortOrder.Ascending;
            CLV.Sort();

        }
        private void carListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carListView.SelectedItems.Count == 0)
                return;

            int id = Int32.Parse(carListView.SelectedItems[0].SubItems[0].Text);
            selectedCarId = id;


        }
        private void updateList()
        {
            var CLV = carListView;
            List<Car> cars = Database.getCars();

            ListViewItem[] listViewItems = new ListViewItem[cars.Count];
            cars.ForEach(car =>
            {
                Debug.WriteLine(car.Id);
                listViewItems[cars.IndexOf(car)] = new ListViewItem(new string[] { car.Id.ToString(), car.Make, car.Model, car.YearOfProduction.ToString(), car.Mileage.ToString(), car.EngineCapacity.ToString(), car.EnginePower.ToString(), car.Color, car.FuelType, car.Gearbox, car.BodyType, car.CountryOfOrigin, car.VIN, (((double)car.Price) / 100).ToString() });
            }
            );
            CLV.Items.Clear();
            CLV.Items.AddRange(listViewItems);
            CLV.Sort();
        }
        private void carListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            carListView.Sort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.removeCar(selectedCarId);
            updateList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var make = makeInput.Text.ToString();
            var model = modelInput.Text.ToString();
            var yearOfProduction = Int32.Parse(yearOfProductionInput.Text.ToString());
            var mileage = Int32.Parse(mileageInput.Text.ToString());
            var engineCapacity = Int32.Parse(engineCapacityInput.Text.ToString());
            var enginePower = Int32.Parse(enginePowerInput.Text.ToString());
            var color = colorInput.Text.ToString();
            var fuelType = fuelTypeInput.Text.ToString();
            var gearbox = gearBoxInput.Text.ToString();
            var bodyType = bodyTypeInput.Text.ToString();
            var countryOfOrigin = countryOfOriginInput.Text.ToString();
            var vin = vinInput.Text.ToString();
            var price = Int32.Parse(priceInput.Text.ToString());
            if (make.Length == 0 || model.Length == 0 || yearOfProduction == 0 || mileage == 0 || engineCapacity == 0 || enginePower == 0 || color.Length == 0 || fuelType.Length == 0 || gearbox.Length == 0 || bodyType.Length == 0 || countryOfOrigin.Length == 0 || vin.Length == 0 || price == 0)
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione");
                return;
            }
            Car car = new Car()
            {
                Make = make,
                Model = model,
                YearOfProduction = yearOfProduction,
                Mileage = mileage,
                EngineCapacity = engineCapacity,
                EnginePower = enginePower,
                Color = color,
                FuelType = fuelType,
                Gearbox = gearbox,
                BodyType = bodyType,
                CountryOfOrigin = countryOfOrigin,
                VIN = vin,
                Price = price
            };
            if (isEditing)
            {
                var oldCar = Database.getCar(selectedCarId);
                Database.removeCar(oldCar.Id);
                car.Id = oldCar.Id;
            }
            Database.addCar(car);
            updateList();

            makeInput.Text = "";
            modelInput.Text = "";
            yearOfProductionInput.Text = "";
            mileageInput.Text = "";
            engineCapacityInput.Text = "";
            enginePowerInput.Text = "";
            colorInput.Text = "";
            fuelTypeInput.Text = "";
            gearBoxInput.Text = "";
            bodyTypeInput.Text = "";
            countryOfOriginInput.Text = "";
            vinInput.Text = "";
            priceInput.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedCarId < 0)
            {
                MessageBox.Show("Prosze wybrać auto");
                return;
            }
            button2.Text = "Edytuj";
            isEditing = true;
            var car = Database.getCar(selectedCarId);
            makeInput.Text = car.Make;
            modelInput.Text = car.Model;
            yearOfProductionInput.Text = car.YearOfProduction.ToString();
            mileageInput.Text = car.Mileage.ToString();
            engineCapacityInput.Text = car.EngineCapacity.ToString();
            enginePowerInput.Text = car.EnginePower.ToString();
            colorInput.Text = car.Color;
            fuelTypeInput.Text = car.FuelType;
            gearBoxInput.Text = car.Gearbox;
            bodyTypeInput.Text = car.BodyType;
            countryOfOriginInput.Text = car.CountryOfOrigin;
            vinInput.Text = car.VIN;
            priceInput.Text = car.Price.ToString();

            tabController.SelectTab("addCarTab");

        }



        private void tabChanged(object sender, EventArgs e)
        {
            var tab = tabController.SelectedTab;

            if (tab == tabController.TabPages["carListTab"] && isEditing)
            {
                isEditing = false;
                makeInput.Text = "";
                modelInput.Text = "";
                yearOfProductionInput.Text = "";
                mileageInput.Text = "";
                engineCapacityInput.Text = "";
                enginePowerInput.Text = "";
                colorInput.Text = "";
                fuelTypeInput.Text = "";
                gearBoxInput.Text = "";
                bodyTypeInput.Text = "";
                countryOfOriginInput.Text = "";
                vinInput.Text = "";
                priceInput.Text = "";
                button2.Text = "Dodaj";

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var searchQuery = textBox1.Text.ToString();
            var CLV = carListView;
            List<Car> cars = Database.getCars();
            cars = cars.FindAll(car => car.Make.ToLower().Contains(searchQuery.ToLower()) || car.Model.ToLower().Contains(searchQuery.ToLower()) || car.Color.ToLower().Contains(searchQuery.ToLower()) || car.FuelType.ToLower().Contains(searchQuery.ToLower()) || car.Gearbox.ToLower().Contains(searchQuery.ToLower()) || car.BodyType.ToLower().Contains(searchQuery.ToLower()) || car.CountryOfOrigin.ToLower().Contains(searchQuery.ToLower()) || car.VIN.ToLower().Contains(searchQuery.ToLower()));
            ListViewItem[] listViewItems = new ListViewItem[cars.Count];
            cars.ForEach(car =>
            {
                Debug.WriteLine(car.Id);
                listViewItems[cars.IndexOf(car)] = new ListViewItem(new string[] { car.Id.ToString(), car.Make, car.Model, car.YearOfProduction.ToString(), car.Mileage.ToString(), car.EngineCapacity.ToString(), car.EnginePower.ToString(), car.Color, car.FuelType, car.Gearbox, car.BodyType, car.CountryOfOrigin, car.VIN, (((double)car.Price) / 100).ToString() });
            }
            );
            CLV.Items.Clear();
            CLV.Items.AddRange(listViewItems);
            CLV.Sort();
        }

    }
}