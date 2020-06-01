using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TouchlessLib;

namespace FAMS
{
    public partial class member_manage : Form
    {
        public string member_id = "";
        public String pictureFilename = "";
        public Boolean isPictureChanged = false;

        public member_manage()
        {
            InitializeComponent();

            martial_status.SelectedIndex = 0;
            gender.SelectedIndex = 0;
            document_type.SelectedIndex = 0;

            picture.Width = 240;
            picture.Height = 180;
        }

        private void member_manage_Load(object sender, EventArgs e)
        {
            if (member_id.Trim() != String.Empty)
            {
                GF.showLoading(this);
                Dictionary<string, string> values = new Dictionary<string, string>()
                {
                    { "member_id" , member_id.Trim() }
                };

                Dictionary<String, Object> Obj = DB.Post("Member/getMemberData/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                    member_no.Text = (Item["member_no"] ?? "").ToString();
                    current_member_type.Text = (Item["current_member_type"] ?? "").ToString();
                    during_date.Text = (Item["during_date"] ?? "").ToString();
                    first_date.Text = GF.formatDBDateTime((Item["create_date"] ?? "").ToString());
                    current_contract_no.Text = (Item["contract_no"] ?? "").ToString();

                    firstname_th.Text = (Item["firstname_th"] ?? "").ToString();
                    lastname_th.Text = (Item["lastname_th"] ?? "").ToString();
                    nickname_th.Text = (Item["nickname_th"] ?? "").ToString();
                    firstname_en.Text = (Item["firstname_en"] ?? "").ToString();
                    lastname_en.Text = (Item["lastname_en"] ?? "").ToString();
                    nickname_en.Text = (Item["nickname_en"] ?? "").ToString();

                    martial_status.Text = Item["martial_status"].ToString();
                    if ((Item["birthday"] ?? "").ToString() != String.Empty)
                    {
                        birthday.Text = Item["birthday"].ToString();
                        current_age.Text = GF.calculateAge(Item["birthday"].ToString());
                    }
                    if ((Item["document_type"] ?? "").ToString() != String.Empty)
                        document_type.Text = Item["document_type"].ToString();
                    document_no.Text = (Item["document_no"] ?? "").ToString();
                    email.Text = (Item["email"] ?? "").ToString();
                    occupation.Text = (Item["occupation"] ?? "").ToString();
                    gender.Text = Item["gender"].ToString();
                    address.Text = (Item["address"] ?? "").ToString();

                    company_name.Text = (Item["company_name"] ?? "").ToString();
                    work_phone.Text = (Item["work_phone"] ?? "").ToString();
                    home_phone.Text = (Item["home_phone"] ?? "").ToString();
                    mobile_phone.Text = (Item["mobile_phone"] ?? "").ToString();

                    emergency_contact_name.Text = (Item["emergency_contact_name"] ?? "").ToString();
                    emergency_contact_phone.Text = (Item["emergency_contact_phone"] ?? "").ToString();
                    emergency_contact_relationship.Text = (Item["emergency_contact_relationship"] ?? "").ToString();

                    weight.Text = (Item["weight"] ?? "").ToString();
                    height.Text = (Item["height"] ?? "").ToString();
                    congenital_disease.Text = (Item["congenital_disease"] ?? "").ToString();

                    pictureFilename = (Item["image_file"] ?? "").ToString();
                    if (pictureFilename.Trim() != String.Empty) GF.getImage(pictureFilename, ref picture, "member_picture");
                }

                GF.closeLoading();
            }
            else picture.Visible = false;
        }

        Boolean validateForm()
        {
            Boolean halt = false;
            Control haltControl = null;

            List<int> tabIndex = new List<int>();

            foreach (Control ctl in this.Controls)
            {
                string type = ctl.GetType().ToString().ToUpper();
                if (type.IndexOf("BUTTON") == -1 && type.IndexOf("LABEL") == -1 && type.IndexOf("GROUPBOX") == -1 && type.IndexOf("PICTUREBOX") == -1 && type.IndexOf("PANEL") == -1 && (ctl.Tag ?? "").ToString() != String.Empty)
                {
                    tabIndex.Add(ctl.TabIndex);
                    Console.WriteLine(ctl.TabIndex.ToString());
                }
            }

            tabIndex.Sort();

            foreach (int index in tabIndex)
            {
                Control ctl = this.Controls.Cast<Control>().Where(p => p.TabIndex == index).First();
                string type = ctl.GetType().ToString().ToUpper();

                if (type.IndexOf("TEXTBOX") > -1)
                {
                    if (type.IndexOf("MASKED") > -1) // MaskedTextBox
                    {
                        if (((MaskedTextBox)ctl).Text.Trim().Length < 10)
                        {
                            halt = true;
                            haltControl = ctl;
                            break;
                        }
                    }
                    else // Simple Textbox
                    {
                        if (!((TextBox)ctl).ReadOnly)
                        {
                            if (((TextBox)ctl).Text.Trim() == String.Empty)
                            {
                                halt = true;
                                haltControl = ctl;
                                break;
                            }
                        }
                    }
                }
                if (type.IndexOf("COMBOBOX") > -1)
                {
                    if (((ComboBox)ctl).Text.Trim() == String.Empty)
                    {
                        halt = true;
                        haltControl = ctl;
                        break;
                    }
                }
            }

            if (halt)
            {
                GF.Error("กรุณากรอก '" + haltControl.Tag.ToString() + "'");
                haltControl.Select();
                return false;
            }

            if (!GF.validateDateTime(birthday))
                return false;
            
            return true;
        }

        private void weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void height_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                Dictionary<string, string> values = new Dictionary<string, string>();

                values = new Dictionary<string, string>
                {
                    { "firstname_th", firstname_th.Text.Trim() },
                    { "lastname_th", lastname_th.Text.Trim() },
                    { "nickname_th", nickname_th.Text.Trim() },
                    { "martial_status", martial_status.Text.Trim() },
                    { "birthday", birthday.Text.Trim() },
                    { "document_type", document_type.Text.Trim() },
                    { "document_no", document_no.Text.Trim() },
                    { "gender", gender.Text.Trim() },
                    { "mobile_phone", mobile_phone.Text.Trim() },
                    { "create_by", GF.userID },
                    { "create_branch_id", GF.Settings("branch_id") },
                    { "member_prefix", GF.Settings("member_prefix") }
                };

                if (firstname_en.Text.Trim() != String.Empty) values.Add("firstname_en", firstname_en.Text.Trim());
                if (lastname_en.Text.Trim() != String.Empty) values.Add("lastname_en", lastname_en.Text.Trim());
                if (nickname_en.Text.Trim() != String.Empty) values.Add("nickname_en", nickname_en.Text.Trim());
                if (email.Text.Trim() != String.Empty) values.Add("email", email.Text.Trim());
                if (occupation.Text.Trim() != String.Empty) values.Add("occupation", occupation.Text.Trim());
                if (address.Text.Trim() != String.Empty) values.Add("address", address.Text.Trim());
                if (company_name.Text.Trim() != String.Empty) values.Add("company_name", company_name.Text.Trim());
                if (work_phone.Text.Trim() != String.Empty) values.Add("work_phone", work_phone.Text.Trim());
                if (home_phone.Text.Trim() != String.Empty) values.Add("home_phone", home_phone.Text.Trim());
                if (emergency_contact_name.Text.Trim() != String.Empty) values.Add("emergency_contact_name", emergency_contact_name.Text.Trim());
                if (emergency_contact_phone.Text.Trim() != String.Empty) values.Add("emergency_contact_phone", emergency_contact_phone.Text.Trim());
                if (emergency_contact_relationship.Text.Trim() != String.Empty) values.Add("emergency_contact_relationship", emergency_contact_relationship.Text.Trim());
                if (weight.Text.Trim() != String.Empty) values.Add("weight", weight.Text.Trim());
                if (height.Text.Trim() != String.Empty) values.Add("height", height.Text.Trim());
                if (congenital_disease.Text.Trim() != String.Empty) values.Add("congenital_disease", congenital_disease.Text.Trim());

                if (member_id != String.Empty) values.Add("member_id", member_id);
                if (member_no.Text.Trim() != String.Empty) values.Add("member_no", member_no.Text.Trim());

                if(member_no.Text.Trim() != String.Empty)
                    if (isPictureChanged)
                    {
                        if (pictureFilename != String.Empty)
                            values.Add("image_file", member_no.Text.Trim() + ".jpg");

                        if (pictureFilename.Trim() != String.Empty)
                            if (!FTP.upload("member_picture", GF.Settings("tmp_path") + pictureFilename, member_no.Text.Trim() + ".jpg"))
                            {
                                GF.Error("เกิดความผิดพลาดในการ upload ไฟล์รูปภาพไปยัง server !!");
                                return;
                            }
                    }

                GF.showLoading(this);
                Dictionary<String, Object> result = DB.Post("Member/manageMember/", values);

                if (result == null)
                {
                    GF.Error("เกิดความผิดพลาด !!");
                    GF.closeLoading();
                    return;
                }

                member_id = result["member_id"].ToString();
                member_no.Text = (result["member_no"] ?? "").ToString();

                ((member)this.Owner).getData();
                this.Close();
            }
        }

        private void picture_Click(object sender, EventArgs e)
        {
            if (member_no.Text.Trim() == String.Empty || member_id.Trim() == String.Empty)
            {
                GF.Error("ต้องมี 'หมายเลขสมาชิก' ก่อน !!");
                return;
            }

            using (TouchlessMgr manager = new TouchlessMgr())
            {
                if (manager.Cameras.Count > 1)
                {
                    using (member_picture memberPicture = new member_picture(member_no.Text.Trim()))
                    {
                        memberPicture.Owner = this;
                        memberPicture.ShowDialog();
                        this.BringToFront();
                        this.Activate();
                    }
                }
                else
                {
                    GF.Error("ไม่พบ กล้อง WebCam !!\r\nกรุณาติดตั้ง กล้อง WebCam ก่อน !");
                    return;
                }
            }

            if (member_no.Text.Trim() != String.Empty && pictureFilename.Trim() != string.Empty)
            {
                GF.getImage(GF.Settings("tmp_path") + pictureFilename, ref picture, "member_picture");
            }
        }

        private void member_manage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (picture.Image != null) picture.Image.Dispose();
            if (GF.tmpImg != null) GF.tmpImg.Dispose();

            DirectoryInfo downloadedMessageInfo = new DirectoryInfo(GF.Settings("tmp_path"));

            foreach (FileInfo file in downloadedMessageInfo.GetFiles())
            {
                file.Delete();
            }
            /*if (pictureFilename.Trim() != String.Empty)
                if (File.Exists(GF.Settings("tmp_path + pictureFilename))
                    File.Delete(GF.Settings("tmp_path + pictureFilename);*/
        }

        private void birthday_Leave(object sender, EventArgs e)
        {
            if(GF.validateDateTime(birthday))
                if (birthday.MaskFull)
                    current_age.Text = GF.calculateAge(birthday.Text);
        }
    }
}
