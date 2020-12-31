using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMS
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        //登录按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                dologin();
            }
            else
            {
                MessageBox.Show("输入有空，请重试");
            }
        }

        //是否允许登陆
        public void dologin()
        {
            if (radioButtonUser.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from t_user where id='{textBox1.Text}' and psw = '{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    Data.UID = dc["id"].ToString();
                    Data.UName = dc["name"].ToString();
                    MessageBox.Show("登陆成功");
                    this.Hide();
                    user1 user = new user1();
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
                dao.DaoClose();
                
            }
            if (radioButtonAdmin.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from t_admin where id='{textBox1.Text}' and psw = '{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登陆成功");
                    this.Hide();
                    admin1 admin = new admin1();
                   admin.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
                dao.DaoClose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
