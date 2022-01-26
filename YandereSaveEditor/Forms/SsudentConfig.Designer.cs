﻿namespace YanSimSaveEditor
{
    partial class StudentConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentConfig));
            this.StudentSelect = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.Portrait = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.DeathCheckbox = new System.Windows.Forms.CheckBox();
            this.PhotographedCheckbox = new System.Windows.Forms.CheckBox();
            this.PantyshotCheckbox = new System.Windows.Forms.CheckBox();
            this.FriendCheckbox = new System.Windows.Forms.CheckBox();
            this.GenderCombobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ClubCombobox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.StrengthCombobox = new System.Windows.Forms.ComboBox();
            this.CrushTextbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BustTextbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.NicknameTextbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.RealnameTextbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.DescTextbox = new System.Windows.Forms.TextBox();
            this.DyingCheckbox = new System.Windows.Forms.CheckBox();
            this.RivalCheckBox = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ReputationTextbox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.HairCombobox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ClassTextbox = new System.Windows.Forms.TextBox();
            this.SeatTextbox = new System.Windows.Forms.TextBox();
            this.PersonaCombobox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.KidnapChekbox = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.AccessoryCombobox = new System.Windows.Forms.ComboBox();
            this.idTextbox = new System.Windows.Forms.TextBox();
            this.noImageLabel = new System.Windows.Forms.Label();
            this.randomButton = new System.Windows.Forms.Button();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.hairTextBox = new System.Windows.Forms.TextBox();
            this.exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Portrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentSelect
            // 
            this.StudentSelect.FormattingEnabled = true;
            this.StudentSelect.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
            this.StudentSelect.Location = new System.Drawing.Point(299, 1);
            this.StudentSelect.Name = "StudentSelect";
            this.StudentSelect.Size = new System.Drawing.Size(64, 21);
            this.StudentSelect.TabIndex = 0;
            this.StudentSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.StudentSelect.SelectionChangeCommitted += new System.EventHandler(this.StudentSelect_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student (by ID)";
            // 
            // Portrait
            // 
            this.Portrait.Location = new System.Drawing.Point(-3, 1);
            this.Portrait.Name = "Portrait";
            this.Portrait.Size = new System.Drawing.Size(162, 156);
            this.Portrait.TabIndex = 2;
            this.Portrait.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Class:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Seat:";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(12, 255);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 5;
            this.idLabel.Text = "ID";
            this.idLabel.Click += new System.EventHandler(this.idLabel_Click);
            // 
            // DeathCheckbox
            // 
            this.DeathCheckbox.AutoSize = true;
            this.DeathCheckbox.Location = new System.Drawing.Point(218, 28);
            this.DeathCheckbox.Name = "DeathCheckbox";
            this.DeathCheckbox.Size = new System.Drawing.Size(58, 17);
            this.DeathCheckbox.TabIndex = 6;
            this.DeathCheckbox.Text = "Dead?";
            this.DeathCheckbox.UseVisualStyleBackColor = true;
            // 
            // PhotographedCheckbox
            // 
            this.PhotographedCheckbox.AutoSize = true;
            this.PhotographedCheckbox.Location = new System.Drawing.Point(218, 51);
            this.PhotographedCheckbox.Name = "PhotographedCheckbox";
            this.PhotographedCheckbox.Size = new System.Drawing.Size(99, 17);
            this.PhotographedCheckbox.TabIndex = 7;
            this.PhotographedCheckbox.Text = "Photographed?";
            this.PhotographedCheckbox.UseVisualStyleBackColor = true;
            // 
            // PantyshotCheckbox
            // 
            this.PantyshotCheckbox.AutoSize = true;
            this.PantyshotCheckbox.Location = new System.Drawing.Point(218, 74);
            this.PantyshotCheckbox.Name = "PantyshotCheckbox";
            this.PantyshotCheckbox.Size = new System.Drawing.Size(84, 17);
            this.PantyshotCheckbox.TabIndex = 8;
            this.PantyshotCheckbox.Text = "Panty Shot?";
            this.PantyshotCheckbox.UseVisualStyleBackColor = true;
            // 
            // FriendCheckbox
            // 
            this.FriendCheckbox.AutoSize = true;
            this.FriendCheckbox.Location = new System.Drawing.Point(320, 74);
            this.FriendCheckbox.Name = "FriendCheckbox";
            this.FriendCheckbox.Size = new System.Drawing.Size(61, 17);
            this.FriendCheckbox.TabIndex = 9;
            this.FriendCheckbox.Text = "Friend?";
            this.FriendCheckbox.UseVisualStyleBackColor = true;
            // 
            // GenderCombobox
            // 
            this.GenderCombobox.FormattingEnabled = true;
            this.GenderCombobox.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.GenderCombobox.Location = new System.Drawing.Point(304, 206);
            this.GenderCombobox.Name = "GenderCombobox";
            this.GenderCombobox.Size = new System.Drawing.Size(121, 21);
            this.GenderCombobox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Gender";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Club";
            // 
            // ClubCombobox
            // 
            this.ClubCombobox.FormattingEnabled = true;
            this.ClubCombobox.Items.AddRange(new object[] {
            "0 - Clubless",
            "1 - Cooking",
            "2 - Drama",
            "3 - Occult",
            "4 - Art",
            "5 - Light Club",
            "6 - Martial Arts",
            "7 - Photography",
            "8 - Science",
            "9 - Sports",
            "10 - Gardening",
            "11 - Gaming",
            "12 - Student Council",
            "13 - Bullies",
            "14 - Delinquents",
            "99 - ?????",
            "100 - (Occupation) Teacher",
            "101 - (Occupation) Gym Teacher",
            "102 - (Occupation) School Nurse"});
            this.ClubCombobox.Location = new System.Drawing.Point(304, 229);
            this.ClubCombobox.Name = "ClubCombobox";
            this.ClubCombobox.Size = new System.Drawing.Size(121, 21);
            this.ClubCombobox.TabIndex = 13;
            this.ClubCombobox.SelectedIndexChanged += new System.EventHandler(this.ClubCombobox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(220, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Self Defense";
            // 
            // StrengthCombobox
            // 
            this.StrengthCombobox.FormattingEnabled = true;
            this.StrengthCombobox.Items.AddRange(new object[] {
            "0 - Incapable",
            "1 - Very Weak",
            "2 - Weak",
            "3 - Strong",
            "4 - Very Strong",
            "5 - Peak Physical Strength",
            "6 - Extensive Self-Defense Training",
            "7 - Carries Pepper Spray",
            "8 - Armed",
            "9 - Invicible",
            "99 - ?????"});
            this.StrengthCombobox.Location = new System.Drawing.Point(304, 252);
            this.StrengthCombobox.Name = "StrengthCombobox";
            this.StrengthCombobox.Size = new System.Drawing.Size(121, 21);
            this.StrengthCombobox.TabIndex = 15;
            this.StrengthCombobox.SelectedIndexChanged += new System.EventHandler(this.StrengthTextbox_SelectedIndexChanged);
            // 
            // CrushTextbox
            // 
            this.CrushTextbox.Location = new System.Drawing.Point(303, 275);
            this.CrushTextbox.Name = "CrushTextbox";
            this.CrushTextbox.Size = new System.Drawing.Size(121, 20);
            this.CrushTextbox.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Crush (ID)";
            // 
            // BustTextbox
            // 
            this.BustTextbox.Location = new System.Drawing.Point(303, 297);
            this.BustTextbox.Name = "BustTextbox";
            this.BustTextbox.Size = new System.Drawing.Size(121, 20);
            this.BustTextbox.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(220, 304);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Bust (0.0-2.0)";
            // 
            // NicknameTextbox
            // 
            this.NicknameTextbox.Location = new System.Drawing.Point(12, 321);
            this.NicknameTextbox.Name = "NicknameTextbox";
            this.NicknameTextbox.Size = new System.Drawing.Size(185, 20);
            this.NicknameTextbox.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 305);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Nickname";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 344);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Real Name";
            // 
            // RealnameTextbox
            // 
            this.RealnameTextbox.Location = new System.Drawing.Point(12, 360);
            this.RealnameTextbox.Name = "RealnameTextbox";
            this.RealnameTextbox.Size = new System.Drawing.Size(185, 20);
            this.RealnameTextbox.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 383);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Description (May Not Work)";
            // 
            // DescTextbox
            // 
            this.DescTextbox.Location = new System.Drawing.Point(12, 399);
            this.DescTextbox.Multiline = true;
            this.DescTextbox.Name = "DescTextbox";
            this.DescTextbox.Size = new System.Drawing.Size(185, 85);
            this.DescTextbox.TabIndex = 25;
            // 
            // DyingCheckbox
            // 
            this.DyingCheckbox.AutoSize = true;
            this.DyingCheckbox.Location = new System.Drawing.Point(320, 28);
            this.DyingCheckbox.Name = "DyingCheckbox";
            this.DyingCheckbox.Size = new System.Drawing.Size(59, 17);
            this.DyingCheckbox.TabIndex = 27;
            this.DyingCheckbox.Text = "Dying?";
            this.DyingCheckbox.UseVisualStyleBackColor = true;
            // 
            // RivalCheckBox
            // 
            this.RivalCheckBox.AutoSize = true;
            this.RivalCheckBox.Enabled = false;
            this.RivalCheckBox.Location = new System.Drawing.Point(320, 51);
            this.RivalCheckBox.Name = "RivalCheckBox";
            this.RivalCheckBox.Size = new System.Drawing.Size(56, 17);
            this.RivalCheckBox.TabIndex = 28;
            this.RivalCheckBox.Text = "Rival?";
            this.RivalCheckBox.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(-2, 165);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Accessory";
            // 
            // ReputationTextbox
            // 
            this.ReputationTextbox.Location = new System.Drawing.Point(303, 319);
            this.ReputationTextbox.Name = "ReputationTextbox";
            this.ReputationTextbox.Size = new System.Drawing.Size(121, 20);
            this.ReputationTextbox.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(220, 322);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Reputation";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // HairCombobox
            // 
            this.HairCombobox.FormattingEnabled = true;
            this.HairCombobox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "112",
            "113",
            "114",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "122",
            "123",
            "124",
            "125",
            "126",
            "127",
            "128",
            "129",
            "130",
            "131",
            "132",
            "133",
            "134",
            "135",
            "136",
            "137",
            "138",
            "139",
            "140",
            "141",
            "142",
            "143",
            "144",
            "145",
            "146",
            "147",
            "148",
            "149",
            "150",
            "151",
            "152",
            "153",
            "154",
            "155",
            "156",
            "157",
            "158",
            "159",
            "160",
            "161",
            "162",
            "163",
            "164",
            "165",
            "166",
            "167",
            "168",
            "169",
            "170",
            "171",
            "172",
            "173",
            "174",
            "175",
            "176",
            "177",
            "178",
            "179",
            "180",
            "181",
            "182",
            "183",
            "184",
            "185",
            "186",
            "187",
            "188",
            "189",
            "190",
            "191",
            "192",
            "193",
            "194",
            "195",
            "196",
            "197",
            "198",
            "199",
            "200"});
            this.HairCombobox.Location = new System.Drawing.Point(303, 341);
            this.HairCombobox.Name = "HairCombobox";
            this.HairCombobox.Size = new System.Drawing.Size(121, 21);
            this.HairCombobox.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(220, 341);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Hairstyle";
            // 
            // ClassTextbox
            // 
            this.ClassTextbox.Location = new System.Drawing.Point(53, 185);
            this.ClassTextbox.Name = "ClassTextbox";
            this.ClassTextbox.Size = new System.Drawing.Size(100, 20);
            this.ClassTextbox.TabIndex = 35;
            // 
            // SeatTextbox
            // 
            this.SeatTextbox.Location = new System.Drawing.Point(53, 207);
            this.SeatTextbox.Name = "SeatTextbox";
            this.SeatTextbox.Size = new System.Drawing.Size(100, 20);
            this.SeatTextbox.TabIndex = 36;
            // 
            // PersonaCombobox
            // 
            this.PersonaCombobox.FormattingEnabled = true;
            this.PersonaCombobox.Items.AddRange(new object[] {
            "0 - (Supposedly) Devoted",
            "1 - Loner",
            "2 - Teacher\'s Pet",
            "3 - Heroic",
            "4 - Coward",
            "5 - Evil",
            "6 - Social Butterfly",
            "7 - Lovestruck",
            "8 - Dangerous",
            "9 - Strict",
            "10 - Phone Addict",
            "11 - Fragile",
            "12 - Spiteful",
            "13 - Sleuth",
            "14 - Stalker",
            "15 - Protective",
            "16 - Tough",
            "99 - ?????"});
            this.PersonaCombobox.Location = new System.Drawing.Point(303, 364);
            this.PersonaCombobox.Name = "PersonaCombobox";
            this.PersonaCombobox.Size = new System.Drawing.Size(121, 21);
            this.PersonaCombobox.TabIndex = 37;
            this.PersonaCombobox.SelectedIndexChanged += new System.EventHandler(this.PersonaCombobox_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(220, 363);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "Personality";
            // 
            // KidnapChekbox
            // 
            this.KidnapChekbox.AutoSize = true;
            this.KidnapChekbox.Location = new System.Drawing.Point(218, 98);
            this.KidnapChekbox.Name = "KidnapChekbox";
            this.KidnapChekbox.Size = new System.Drawing.Size(83, 17);
            this.KidnapChekbox.TabIndex = 40;
            this.KidnapChekbox.Text = "Kidnapped?";
            this.KidnapChekbox.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(220, 118);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(194, 13);
            this.label17.TabIndex = 41;
            this.label17.Text = "The above value doesn\'t mean they will";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(220, 131);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(185, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "Be in your basement. See main config";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(350, 464);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 43;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(269, 464);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 44;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(275, 188);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(145, 13);
            this.label19.TabIndex = 45;
            this.label19.Text = "*Some things require a restart";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(369, -1);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(56, 23);
            this.ApplyButton.TabIndex = 47;
            this.ApplyButton.Text = "Get ID";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // AccessoryCombobox
            // 
            this.AccessoryCombobox.FormattingEnabled = true;
            this.AccessoryCombobox.Items.AddRange(new object[] {
            "0 - (Male Student) None /(Female Student) None/(Staff) None",
            "1 - (MS) Red Bandana/(FS) Eyepatch/(S) Rectangular Glasses",
            "2 - (MS) One Opaque Lens Glasses/(FS) Bandages Over Eye/(S) Round Glasses",
            "3 - (MS) Silver Earring/(FS) Demon Ring/(S) Oval Glasses)",
            "4 - (MS) Blue Glasses/(FS) Golden Earrings + Purple Scrunchie/(S) Glasses",
            "5 - (MS) Earring + Round Earlobe Piercings/(FS) Spider Choker/(S) Rectangular Gla" +
                "sses Without Top Rim",
            "6 - (MS) Earlobe Piercing/(FS) Bracelet/(S) Glasses Without Rop Rim",
            "7 - (MS) Double Earrings/(FS) Blue Glasses/(S) Whistle Necklace",
            "8 - (MS) Earlobe Piercings/(FS) Glasses with Chain/(S) Nurse Hat",
            "9 - (MS) Earring + Spiked Earlobe Piercings/(FS) Tiger Scarf",
            "10 - (MS) Blue Ascot/(FS) Feathers Behind Left Ear",
            "11 - (MS) Brown Goatee/(FS) Dragon Eyepatch",
            "12 - (MS) Dog Collar/(FS) Lilac Ascot",
            "13 - (MS) Blue Glasses (Geiju)/(FS) Brown Glasses ",
            "14 - (MS) Orange Goatee/(FS) Rose Choker",
            "15 - (MS) Blue Goatee",
            "16 - (MS) Headphones",
            "17 - (MS) Lip Piercing"});
            this.AccessoryCombobox.Location = new System.Drawing.Point(53, 163);
            this.AccessoryCombobox.Name = "AccessoryCombobox";
            this.AccessoryCombobox.Size = new System.Drawing.Size(367, 21);
            this.AccessoryCombobox.TabIndex = 48;
            this.AccessoryCombobox.SelectedIndexChanged += new System.EventHandler(this.AccessoryCombobox_SelectedIndexChanged);
            // 
            // idTextbox
            // 
            this.idTextbox.Cursor = System.Windows.Forms.Cursors.No;
            this.idTextbox.Location = new System.Drawing.Point(53, 252);
            this.idTextbox.Name = "idTextbox";
            this.idTextbox.ReadOnly = true;
            this.idTextbox.Size = new System.Drawing.Size(100, 20);
            this.idTextbox.TabIndex = 49;
            // 
            // noImageLabel
            // 
            this.noImageLabel.AutoSize = true;
            this.noImageLabel.Location = new System.Drawing.Point(9, 9);
            this.noImageLabel.Name = "noImageLabel";
            this.noImageLabel.Size = new System.Drawing.Size(0, 13);
            this.noImageLabel.TabIndex = 50;
            // 
            // randomButton
            // 
            this.randomButton.Location = new System.Drawing.Point(203, 406);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(222, 23);
            this.randomButton.TabIndex = 51;
            this.randomButton.Text = "Random";
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // scheduleButton
            // 
            this.scheduleButton.Location = new System.Drawing.Point(203, 435);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(220, 23);
            this.scheduleButton.TabIndex = 52;
            this.scheduleButton.Text = "Edit Schedule";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Hair";
            // 
            // hairTextBox
            // 
            this.hairTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.hairTextBox.Location = new System.Drawing.Point(53, 229);
            this.hairTextBox.Name = "hairTextBox";
            this.hairTextBox.ReadOnly = true;
            this.hairTextBox.Size = new System.Drawing.Size(100, 20);
            this.hairTextBox.TabIndex = 55;
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(203, 464);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(60, 23);
            this.exportButton.TabIndex = 56;
            this.exportButton.Text = "Export Data";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // StudentConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 487);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.hairTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.scheduleButton);
            this.Controls.Add(this.randomButton);
            this.Controls.Add(this.noImageLabel);
            this.Controls.Add(this.idTextbox);
            this.Controls.Add(this.AccessoryCombobox);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.KidnapChekbox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.PersonaCombobox);
            this.Controls.Add(this.SeatTextbox);
            this.Controls.Add(this.ClassTextbox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.HairCombobox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ReputationTextbox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.RivalCheckBox);
            this.Controls.Add(this.DyingCheckbox);
            this.Controls.Add(this.DescTextbox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.RealnameTextbox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.NicknameTextbox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BustTextbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CrushTextbox);
            this.Controls.Add(this.StrengthCombobox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ClubCombobox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GenderCombobox);
            this.Controls.Add(this.FriendCheckbox);
            this.Controls.Add(this.PantyshotCheckbox);
            this.Controls.Add(this.PhotographedCheckbox);
            this.Controls.Add(this.DeathCheckbox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Portrait);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StudentSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudentConfig";
            this.Text = "Student Configuration";
            this.Load += new System.EventHandler(this.StudentConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Portrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox StudentSelect;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Portrait;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.CheckBox DeathCheckbox;
        private System.Windows.Forms.CheckBox PhotographedCheckbox;
        private System.Windows.Forms.CheckBox PantyshotCheckbox;
        private System.Windows.Forms.CheckBox FriendCheckbox;
        private System.Windows.Forms.ComboBox GenderCombobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ClubCombobox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox StrengthCombobox;
        private System.Windows.Forms.TextBox CrushTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox BustTextbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NicknameTextbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox RealnameTextbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox DescTextbox;
        private System.Windows.Forms.CheckBox DyingCheckbox;
        private System.Windows.Forms.CheckBox RivalCheckBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ReputationTextbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox HairCombobox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox ClassTextbox;
        private System.Windows.Forms.TextBox SeatTextbox;
        private System.Windows.Forms.ComboBox PersonaCombobox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox KidnapChekbox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label19;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.ComboBox AccessoryCombobox;
        private System.Windows.Forms.TextBox idTextbox;
        private System.Windows.Forms.Label noImageLabel;
        private System.Windows.Forms.Button randomButton;
        private System.Windows.Forms.Button scheduleButton;
        private System.Windows.Forms.TextBox hairTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button exportButton;
    }
}