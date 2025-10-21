using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

public class DynamicForm : Form
{
    private Label myLabel;
    private Button button1;
    private Button button2;

    public DynamicForm()
    {
        this.Text = "Додаткове";
        this.Size = new Size(350, 250); 

        myLabel = new Label();
        myLabel.Text = "Це не рядок";
        myLabel.Location = new Point(50, 30);
        myLabel.AutoSize = true; 

        button1 = new Button();
        button1.Text = "Кнопка";
        button1.Location = new Point(50, 70);
        button1.Size = new Size(200, 30); 

        button2 = new Button();
        button2.Text = "Лимон";
        button2.Location = new Point(50, 120); 
        button2.Size = new Size(200, 30);

        button1.Click += new EventHandler(Button1_Click);
        button2.Click += new EventHandler(Button2_Click);

        this.Controls.Add(myLabel);
        this.Controls.Add(button1);
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        myLabel.Text = "Десь ховається лимон!";

        if (!this.Controls.Contains(button2))
        {
            this.Controls.Add(button2);
            this.Controls.Remove(button1);
        }
    }

    private async void Button2_Click(object sender, EventArgs e)
    {
        myLabel.Text = "Це не моно";
        button1.Text = "Лимон в монобанку!";

        if (this.Controls.Contains(button2))
        {
            this.Controls.Remove(button2);
            this.Controls.Add(button1);
            await Task.Delay(2000);
            button1.Text = "Не тисни";
            myLabel.Text = "Рядок";
        }
    }

    public static void Main()
    {
        Application.Run(new DynamicForm());
    }
}