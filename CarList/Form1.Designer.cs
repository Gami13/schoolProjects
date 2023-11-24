namespace CarList
{
    partial class Form1
    {
        private TabControl tabController;
        private TabPage carListTab;
        private TabPage addCarTab;
        private ListView carListView;
        private Button button1;
        private TextBox makeInput;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox modelInput;
        private TextBox countryOfOriginInput;
        private TextBox textBox10;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox colorInput;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button2;
        private NumericUpDown engineCapacityInput;
        private NumericUpDown enginePowerInput;
        private NumericUpDown yearOfProductionInput;
        private NumericUpDown mileageInput;
        private ComboBox gearBoxInput;
        private ComboBox bodyTypeInput;
        private NumericUpDown vinInput;
        private ComboBox fuelTypeInput;
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabController = new TabControl();
            carListTab = new TabPage();
            textBox1 = new TextBox();
            button3 = new Button();
            button1 = new Button();
            carListView = new ListView();
            addCarTab = new TabPage();
            priceInput = new NumericUpDown();
            label13 = new Label();
            gearBoxInput = new ComboBox();
            bodyTypeInput = new ComboBox();
            vinInput = new NumericUpDown();
            fuelTypeInput = new ComboBox();
            engineCapacityInput = new NumericUpDown();
            enginePowerInput = new NumericUpDown();
            yearOfProductionInput = new NumericUpDown();
            mileageInput = new NumericUpDown();
            button2 = new Button();
            countryOfOriginInput = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            colorInput = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            modelInput = new TextBox();
            makeInput = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabController.SuspendLayout();
            carListTab.SuspendLayout();
            addCarTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)priceInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vinInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)engineCapacityInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enginePowerInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)yearOfProductionInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mileageInput).BeginInit();
            SuspendLayout();
            // 
            // tabController
            // 
            tabController.Controls.Add(carListTab);
            tabController.Controls.Add(addCarTab);
            tabController.Location = new Point(0, 0);
            tabController.Margin = new Padding(0);
            tabController.Name = "tabController";
            tabController.SelectedIndex = 0;
            tabController.Size = new Size(886, 362);
            tabController.TabIndex = 0;
            tabController.SelectedIndexChanged += tabChanged;
            // 
            // carListTab
            // 
            carListTab.Controls.Add(textBox1);
            carListTab.Controls.Add(button3);
            carListTab.Controls.Add(button1);
            carListTab.Controls.Add(carListView);
            carListTab.Location = new Point(4, 24);
            carListTab.Margin = new Padding(0);
            carListTab.Name = "carListTab";
            carListTab.Size = new Size(878, 334);
            carListTab.TabIndex = 0;
            carListTab.Text = "Lista samochodów";
            carListTab.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(796, 64);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(76, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button3
            // 
            button3.Location = new Point(797, 35);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "Edytuj";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(796, 6);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Usuń";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // carListView
            // 
            carListView.Location = new Point(0, 1);
            carListView.Name = "carListView";
            carListView.Size = new Size(791, 333);
            carListView.TabIndex = 0;
            carListView.UseCompatibleStateImageBehavior = false;
            carListView.ColumnClick += carListView_ColumnClick;
            carListView.SelectedIndexChanged += carListView_SelectedIndexChanged;
            // 
            // addCarTab
            // 
            addCarTab.Controls.Add(priceInput);
            addCarTab.Controls.Add(label13);
            addCarTab.Controls.Add(gearBoxInput);
            addCarTab.Controls.Add(bodyTypeInput);
            addCarTab.Controls.Add(vinInput);
            addCarTab.Controls.Add(fuelTypeInput);
            addCarTab.Controls.Add(engineCapacityInput);
            addCarTab.Controls.Add(enginePowerInput);
            addCarTab.Controls.Add(yearOfProductionInput);
            addCarTab.Controls.Add(mileageInput);
            addCarTab.Controls.Add(button2);
            addCarTab.Controls.Add(countryOfOriginInput);
            addCarTab.Controls.Add(label9);
            addCarTab.Controls.Add(label10);
            addCarTab.Controls.Add(label11);
            addCarTab.Controls.Add(label12);
            addCarTab.Controls.Add(colorInput);
            addCarTab.Controls.Add(label5);
            addCarTab.Controls.Add(label6);
            addCarTab.Controls.Add(label7);
            addCarTab.Controls.Add(label8);
            addCarTab.Controls.Add(modelInput);
            addCarTab.Controls.Add(makeInput);
            addCarTab.Controls.Add(label4);
            addCarTab.Controls.Add(label3);
            addCarTab.Controls.Add(label2);
            addCarTab.Controls.Add(label1);
            addCarTab.Location = new Point(4, 24);
            addCarTab.Margin = new Padding(0);
            addCarTab.Name = "addCarTab";
            addCarTab.Size = new Size(878, 334);
            addCarTab.TabIndex = 1;
            addCarTab.Text = "Dodaj samochód";
            addCarTab.UseVisualStyleBackColor = true;
            // 
            // priceInput
            // 
            priceInput.Location = new Point(517, 238);
            priceInput.Name = "priceInput";
            priceInput.Size = new Size(129, 23);
            priceInput.TabIndex = 36;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(455, 240);
            label13.Name = "label13";
            label13.Size = new Size(56, 15);
            label13.TabIndex = 35;
            label13.Text = "Cena (gr)";
            // 
            // gearBoxInput
            // 
            gearBoxInput.FormattingEnabled = true;
            gearBoxInput.Items.AddRange(new object[] { "Automatyczna", "Manualna" });
            gearBoxInput.Location = new Point(124, 178);
            gearBoxInput.Name = "gearBoxInput";
            gearBoxInput.Size = new Size(121, 23);
            gearBoxInput.TabIndex = 34;
            // 
            // bodyTypeInput
            // 
            bodyTypeInput.FormattingEnabled = true;
            bodyTypeInput.Items.AddRange(new object[] { "SUV", "Hatchback", "Sedan", "Kombi", "Coupe", "Van", "Minivan", "Kabriolet" });
            bodyTypeInput.Location = new Point(343, 178);
            bodyTypeInput.Name = "bodyTypeInput";
            bodyTypeInput.Size = new Size(121, 23);
            bodyTypeInput.TabIndex = 33;
            // 
            // vinInput
            // 
            vinInput.Location = new Point(273, 236);
            vinInput.Name = "vinInput";
            vinInput.Size = new Size(129, 23);
            vinInput.TabIndex = 32;
            // 
            // fuelTypeInput
            // 
            fuelTypeInput.FormattingEnabled = true;
            fuelTypeInput.Items.AddRange(new object[] { "Benzyna", "Diesel", "Elektryk", "Gaz" });
            fuelTypeInput.Location = new Point(742, 108);
            fuelTypeInput.Name = "fuelTypeInput";
            fuelTypeInput.Size = new Size(121, 23);
            fuelTypeInput.TabIndex = 31;
            // 
            // engineCapacityInput
            // 
            engineCapacityInput.Location = new Point(349, 109);
            engineCapacityInput.Name = "engineCapacityInput";
            engineCapacityInput.Size = new Size(129, 23);
            engineCapacityInput.TabIndex = 30;
            // 
            // enginePowerInput
            // 
            enginePowerInput.Location = new Point(124, 109);
            enginePowerInput.Name = "enginePowerInput";
            enginePowerInput.Size = new Size(129, 23);
            enginePowerInput.TabIndex = 29;
            // 
            // yearOfProductionInput
            // 
            yearOfProductionInput.Location = new Point(712, 38);
            yearOfProductionInput.Name = "yearOfProductionInput";
            yearOfProductionInput.Size = new Size(129, 23);
            yearOfProductionInput.TabIndex = 28;
            // 
            // mileageInput
            // 
            mileageInput.Location = new Point(484, 38);
            mileageInput.Name = "mileageInput";
            mileageInput.Size = new Size(129, 23);
            mileageInput.TabIndex = 27;
            // 
            // button2
            // 
            button2.Location = new Point(216, 288);
            button2.Name = "button2";
            button2.Size = new Size(447, 23);
            button2.TabIndex = 26;
            button2.Text = "Dodaj";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // countryOfOriginInput
            // 
            countryOfOriginInput.Location = new Point(588, 178);
            countryOfOriginInput.Name = "countryOfOriginInput";
            countryOfOriginInput.Size = new Size(129, 23);
            countryOfOriginInput.TabIndex = 23;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(201, 238);
            label9.Name = "label9";
            label9.Size = new Size(66, 15);
            label9.TabIndex = 19;
            label9.Text = "Numer VIN";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(484, 181);
            label10.Name = "label10";
            label10.Size = new Size(98, 15);
            label10.TabIndex = 18;
            label10.Text = "Kraj pochodzenia";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(259, 181);
            label11.Name = "label11";
            label11.Size = new Size(78, 15);
            label11.TabIndex = 17;
            label11.Text = "Typ nadwozia";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(26, 181);
            label12.Name = "label12";
            label12.Size = new Size(92, 15);
            label12.TabIndex = 16;
            label12.Text = "Skrzynia biegow";
            // 
            // colorInput
            // 
            colorInput.Location = new Point(535, 108);
            colorInput.Name = "colorInput";
            colorInput.Size = new Size(129, 23);
            colorInput.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(494, 111);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 11;
            label5.Text = "Kolor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(674, 111);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 10;
            label6.Text = "Typ paliwa";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(256, 111);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 9;
            label7.Text = "Pojemność (CC)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 111);
            label8.Name = "label8";
            label8.Size = new Size(96, 15);
            label8.TabIndex = 8;
            label8.Text = "Moc silnika (KM)";
            // 
            // modelInput
            // 
            modelInput.Location = new Point(273, 38);
            modelInput.Name = "modelInput";
            modelInput.Size = new Size(129, 23);
            modelInput.TabIndex = 5;
            // 
            // makeInput
            // 
            makeInput.Location = new Point(70, 38);
            makeInput.Name = "makeInput";
            makeInput.Size = new Size(129, 23);
            makeInput.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(426, 41);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 3;
            label4.Text = "Przebieg";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(626, 41);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 2;
            label3.Text = "Rok produkcji";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(226, 41);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "Model";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 41);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Marka";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 361);
            Controls.Add(tabController);
            MaximumSize = new Size(900, 400);
            MinimumSize = new Size(900, 400);
            Name = "Form1";
            Text = "Form1";
            tabController.ResumeLayout(false);
            carListTab.ResumeLayout(false);
            carListTab.PerformLayout();
            addCarTab.ResumeLayout(false);
            addCarTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)priceInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)vinInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)engineCapacityInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)enginePowerInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)yearOfProductionInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)mileageInput).EndInit();
            ResumeLayout(false);
        }

        #endregion


        private NumericUpDown priceInput;
        private Label label13;
        private Button button3;
        private TextBox textBox1;
    }
}