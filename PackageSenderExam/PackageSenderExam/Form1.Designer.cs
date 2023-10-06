namespace PackageSenderExam
{
    partial class Form1
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            paczka = new RadioButton();
            list = new RadioButton();
            pocztowka = new RadioButton();
            groupBox2 = new GroupBox();
            cityInput = new TextBox();
            label3 = new Label();
            postalCodeInput = new TextBox();
            label2 = new Label();
            streetInput = new TextBox();
            label1 = new Label();
            checkPriceBtn = new Button();
            pictureBox1 = new PictureBox();
            priceView = new Label();
            confirmBtn = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(paczka);
            groupBox1.Controls.Add(list);
            groupBox1.Controls.Add(pocztowka);
            groupBox1.Location = new Point(40, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(160, 120);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Rodzaj przesyłki";
            // 
            // paczka
            // 
            paczka.AutoSize = true;
            paczka.Location = new Point(15, 79);
            paczka.Name = "paczka";
            paczka.Size = new Size(61, 19);
            paczka.TabIndex = 2;
            paczka.TabStop = true;
            paczka.Text = "Paczka";
            paczka.UseVisualStyleBackColor = true;
            paczka.CheckedChanged += paczka_CheckedChanged;
            // 
            // list
            // 
            list.AutoSize = true;
            list.Location = new Point(15, 54);
            list.Name = "list";
            list.Size = new Size(43, 19);
            list.TabIndex = 1;
            list.TabStop = true;
            list.Text = "List";
            list.UseVisualStyleBackColor = true;
            list.CheckedChanged += list_CheckedChanged;
            // 
            // pocztowka
            // 
            pocztowka.AutoSize = true;
            pocztowka.Checked = true;
            pocztowka.Location = new Point(15, 29);
            pocztowka.Name = "pocztowka";
            pocztowka.Size = new Size(82, 19);
            pocztowka.TabIndex = 0;
            pocztowka.TabStop = true;
            pocztowka.Text = "Pocztówka";
            pocztowka.UseVisualStyleBackColor = true;
            pocztowka.CheckedChanged += pocztowka_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cityInput);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(postalCodeInput);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(streetInput);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(285, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(245, 187);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dane adresowe";
            // 
            // cityInput
            // 
            cityInput.Location = new Point(22, 136);
            cityInput.Name = "cityInput";
            cityInput.Size = new Size(200, 23);
            cityInput.TabIndex = 5;
            cityInput.TextChanged += cityInput_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 118);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 4;
            label3.Text = "Miasto:";
            // 
            // postalCodeInput
            // 
            postalCodeInput.Location = new Point(22, 90);
            postalCodeInput.Name = "postalCodeInput";
            postalCodeInput.Size = new Size(100, 23);
            postalCodeInput.TabIndex = 3;
            postalCodeInput.TextChanged += postalCodeInput_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 72);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 2;
            label2.Text = "Kod pocztowy:";
            // 
            // streetInput
            // 
            streetInput.Location = new Point(22, 44);
            streetInput.Name = "streetInput";
            streetInput.Size = new Size(200, 23);
            streetInput.TabIndex = 1;
            streetInput.TextChanged += streetInput_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 26);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "Ulica z numerem:";
            // 
            // checkPriceBtn
            // 
            checkPriceBtn.Location = new Point(40, 150);
            checkPriceBtn.Name = "checkPriceBtn";
            checkPriceBtn.Size = new Size(160, 23);
            checkPriceBtn.TabIndex = 2;
            checkPriceBtn.Text = "Sprawdź Cenę";
            checkPriceBtn.UseVisualStyleBackColor = true;
            checkPriceBtn.Click += checkPriceBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.image;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(40, 190);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // priceView
            // 
            priceView.AutoSize = true;
            priceView.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            priceView.Location = new Point(145, 200);
            priceView.Name = "priceView";
            priceView.Size = new Size(0, 25);
            priceView.TabIndex = 4;
            // 
            // confirmBtn
            // 
            confirmBtn.Location = new Point(40, 260);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(490, 23);
            confirmBtn.TabIndex = 5;
            confirmBtn.Text = "Zatwierdź";
            confirmBtn.UseVisualStyleBackColor = true;
            confirmBtn.Click += confirmBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 291);
            Controls.Add(confirmBtn);
            Controls.Add(priceView);
            Controls.Add(pictureBox1);
            Controls.Add(checkPriceBtn);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Nadaj Przesyłkę. PESEL: xxxxxxxxx";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RadioButton paczka;
        private RadioButton list;
        private RadioButton pocztowka;
        private TextBox cityInput;
        private Label label3;
        private TextBox postalCodeInput;
        private Label label2;
        private TextBox streetInput;
        private Label label1;
        private Button checkPriceBtn;
        private PictureBox pictureBox1;
        private Label priceView;
        private Button confirmBtn;
    }
}