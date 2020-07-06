using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Leksema
{
    
    class Leksems
    {
        public string tempSys;
        int strok=1,strtab=0;
        public void analysis(char[] str, DataGridView resu,TextBox txt,DataGridView remp,DataGridView operand)
        {
            //----------------------------Разбиение на строки-------------------------------------
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i]!='\0')
                {
                    if(str[i] == '\n')
                    {
                        resu.Rows.Add();
                        resu[0, strtab].Value = strtab+1;
                        resu[1, strtab].Value = tempSys; 
                        tempSys = null;
                        strtab++;
                    }
                    else
                    {
                        if (tempSys == null && str[i] == ' ')
                        { }else
                        tempSys += str[i];
                    }

                }
            }
            //---------------------Разбор каждой строки------------------------
            List<string> oper = new List<string>() { "using","namespace","publicpartialclass","int","double","if","elseif","else",
                "else","Convert.ToInt32","textBox1.Text","textBox2.Text", "textBox2.Text",";",":","{","}","<",">","/","=","+","-","privatevoid","Math.Tan","Math.Pow","Math.Sin","Math.E",
            "richTextBox1.Text","result.ToString","Environment.NewLine","for"};
            List<char> razd = new List<char>() {'+','-','/','*','=','>','<','!'};
            int strok = 0,m,k,u,y, strok1=0;

            Stack<char> skob = new Stack<char>();
            Stack<int> pol = new Stack<int>();
            for (int j=0;j< strtab; j++)
            {
                m = j;
                k = j;
                u = j;
                y = j;
                char[] arr;
                char[] tp;
                string an = resu[1, j].Value.ToString()+ '\n';
                arr = an.ToCharArray();
                an = "";
                for(int i=0;i<arr.Length;i++)
                {
                    if(arr[i] != '\n')
                    {
                        
                        if (an== "public"|| an == "publicpartial" || an == "private")
                        {
                            i++;
                        }
                        else
                        if (arr[i] == '{')
                        {
                            remp.Rows.Add();
                            remp[0, strok].Value = Convert.ToString(strok + 1);
                            remp[1, strok].Value = "{";
                            remp[2, strok].Value = Convert.ToString(k + 1);
                            remp[3, strok].Value = Convert.ToString(i);
                            strok++;
                            an = "";
                        }
                        else
                        if (arr[i] == '}')
                        {
                            remp.Rows.Add();
                            remp[0, strok].Value = Convert.ToString(strok + 1);
                            remp[1, strok].Value = "}";
                            remp[2, strok].Value = Convert.ToString(k + 1);
                            remp[3, strok].Value = Convert.ToString(i);
                            strok++;
                            an = "";
                        }
                        else
                        if (arr[i] == '.')
                        {
                            an += arr[i];
                            i++;
                        }
                        else if (arr[i] == ','&& !oper.Contains(an))
                        {
                            operand.Rows.Add();
                            operand[0, strok1].Value = Convert.ToString(strok1 + 1);
                            operand[1, strok1].Value = an;
                            operand[2, strok1].Value = Convert.ToString(k + 1);
                            operand[3, strok1].Value = Convert.ToString(i);
                            an = "";
                            strok1++;
                            i++;
                        }
                        else if (arr[i] == ',' && oper.Contains(an))
                        {
                            remp.Rows.Add();
                            remp[0, strok].Value = Convert.ToString(strok + 1);
                            remp[1, strok].Value = an;
                            remp[2, strok].Value = Convert.ToString(k + 1);
                            remp[3, strok].Value = Convert.ToString(i);
                            strok++;
                            an = "";
                            i++;
                        }
                        else
                        if (razd.Contains(arr[i])&&an=="")
                        {
                            remp.Rows.Add();
                            remp[0, strok].Value = Convert.ToString(strok + 1);
                            remp[1, strok].Value = arr[i];
                            remp[2, strok].Value = Convert.ToString(k + 1);
                            remp[3, strok].Value = Convert.ToString(i);
                            strok++;
                            an = "";
                        }
                        else if (razd.Contains(arr[i]) && oper.Contains(an))
                        {
                            remp.Rows.Add();
                            remp[0, strok].Value = Convert.ToString(strok + 1);
                            remp[1, strok].Value = arr[i];
                            remp[2, strok].Value = Convert.ToString(k + 1);
                            remp[3, strok].Value = Convert.ToString(i);
                            strok++;
                            remp.Rows.Add();
                            remp[0, strok].Value = Convert.ToString(strok + 1);
                            remp[1, strok].Value = an;
                            remp[2, strok].Value = Convert.ToString(k + 1);
                            remp[3, strok].Value = Convert.ToString(i);
                            strok++;
                            an = "";
                        }
                        else if (razd.Contains(arr[i]) && !oper.Contains(an))
                        {
                            remp.Rows.Add();
                            remp[0, strok].Value = Convert.ToString(strok + 1);
                            remp[1, strok].Value = arr[i];
                            remp[2, strok].Value = Convert.ToString(k + 1);
                            remp[3, strok].Value = Convert.ToString(i);
                            strok++;
                            operand.Rows.Add();
                            operand[0, strok1].Value = Convert.ToString(strok1 + 1);
                            operand[1, strok1].Value = an;
                            operand[2, strok1].Value = Convert.ToString(k + 1);
                            operand[3, strok1].Value = Convert.ToString(i);
                            an = "";
                            strok1++;
                        }
                        else
                        if (arr[i] == '(' || arr[i] == ')')
                        {
                            if (arr[i] == '(' && an == "" )
                            {
                                remp.Rows.Add();
                                remp[0, strok].Value = Convert.ToString(strok + 1);
                                remp[1, strok].Value = "()";
                                remp[2, strok].Value = Convert.ToString(k + 1);
                                remp[3, strok].Value = Convert.ToString(i);
                                strok++;
                               
                            }
                            else
                            if (arr[i] == '(' && an != "" && an != "button1_Click" || arr[i] == '(' && an != "" && oper.Contains(an) && an != "button1_Click")
                            {

                                remp.Rows.Add();
                                remp[0, strok].Value = Convert.ToString(strok + 1);
                                remp[1, strok].Value = an;
                                remp[2, strok].Value = Convert.ToString(k + 1);
                                remp[3, strok].Value = Convert.ToString(i);
                                an = "";
                                strok++;
                                remp.Rows.Add();
                                remp[0, strok].Value = Convert.ToString(strok + 1);
                                remp[1, strok].Value = "()";
                                remp[2, strok].Value = Convert.ToString(k + 1);
                                remp[3, strok].Value = Convert.ToString(i);
                                strok++;
                                
                            }
                            else if (arr[i] == '(' && an != ""&& an != "button1_Click")
                            {
                                operand.Rows.Add();
                                operand[0, strok1].Value = Convert.ToString(strok1 + 1);
                                operand[1, strok1].Value = an;
                                operand[2, strok1].Value = Convert.ToString(k + 1);
                                operand[3, strok1].Value = Convert.ToString(i);
                                an = "";
                                strok1++;
                            }
                            if (an == "button1_Click")
                            {
                                remp.Rows.Add();
                                remp[0, strok].Value = Convert.ToString(strok + 1);
                                remp[1, strok].Value = "()";
                                remp[2, strok].Value = Convert.ToString(k + 1);
                                remp[3, strok].Value = Convert.ToString(i);
                                strok++;
                                break;
                            }
                            if (arr[i] == ')' && an != "")
                            {
                                if (oper.Contains(an))
                                {
                                    remp.Rows.Add();
                                    remp[0, strok].Value = Convert.ToString(strok + 1);
                                    remp[1, strok].Value = an;
                                    remp[2, strok].Value = Convert.ToString(k + 1);
                                    remp[3, strok].Value = Convert.ToString(i);
                                    an = "";
                                    strok++;
                                }
                                else
                                {
                                    tp = an.ToCharArray();
                                    if (tp[0] > '0' && tp[0] < '9')
                                    {
                                        an = "";
                                    }
                                    else if (tp[0] > 'a' && tp[0] < 'z')
                                    {
                                        operand.Rows.Add();
                                        operand[0, strok1].Value = Convert.ToString(strok1 + 1);
                                        operand[1, strok1].Value = an;
                                        operand[2, strok1].Value = Convert.ToString(k + 1);
                                        operand[3, strok1].Value = Convert.ToString(i);
                                        an = "";
                                        strok1++;
                                    }
                                    
                                }
                                
                            }
                        }else
                        if (arr[i] == ' '|| arr[i] == ';' || arr[i] == ':')
                        {
                            if (oper.Contains(an))
                            {
                                remp.Rows.Add();
                                remp[0, strok].Value = Convert.ToString(strok + 1);
                                remp[1, strok].Value = an;
                                remp[2, strok].Value = Convert.ToString(k + 1);
                                remp[3, strok].Value = Convert.ToString(i);
                                an = "";
                                strok++;
                            }
                            else if (!oper.Contains(an))
                            {
                                if (an == "" && arr[i] == ' ')
                                {}
                                if (an == "button1_Click(")
                                {
                                    break;
                                }
                                else
                                if (arr[i] == ';' || arr[i] == ':')
                                {
                                    if (arr[i] == ';'&&an=="")
                                    {
                                        remp.Rows.Add();
                                        remp[0, strok].Value = Convert.ToString(strok + 1);
                                        remp[1, strok].Value = ";";
                                        remp[2, strok].Value = Convert.ToString(k + 1);
                                        remp[3, strok].Value = Convert.ToString(i);
                                        an = "";
                                        strok++;
                                    }
                                    else if(arr[i] == ';' && an != ""&&!oper.Contains(an))
                                    {
                                        operand.Rows.Add();
                                        operand[0, strok1].Value = Convert.ToString(strok1 + 1);
                                        operand[1, strok1].Value = an;
                                        operand[2, strok1].Value = Convert.ToString(k + 1);
                                        operand[3, strok1].Value = Convert.ToString(i);
                                        an = "";
                                        strok1++;
                                    }
                                    else
                                    if (arr[i] == ':'&&!oper.Contains(an))
                                    {
                                        remp.Rows.Add();
                                        remp[0, strok].Value = Convert.ToString(strok + 1);
                                        remp[1, strok].Value = ":";
                                        remp[2, strok].Value = Convert.ToString(k + 1);
                                        remp[3, strok].Value = Convert.ToString(i);
                                        an = "";
                                        strok++;
                                    } 
                                   
                                }
                                else if(arr[i] != ';' && an!=""|| arr[i] != ':'&& an != "")
                                {
                                    operand.Rows.Add();
                                    operand[0, strok1].Value = Convert.ToString(strok1 + 1);
                                    operand[1, strok1].Value = an;
                                    operand[2, strok1].Value = Convert.ToString(k + 1);
                                    operand[3, strok1].Value = Convert.ToString(i);
                                    an = "";
                                    strok1++;
                                }
                            }
                          
                        }
                        if (razd.Contains(arr[i]))
                        { an = ""; }
                        else if (an == "" && arr[i] == ' ' && arr[i] != ';'|| an == "" && arr[i] == ')' || an == "" && arr[i] == '('|| an == "" && arr[i] == '"' || an == "" && arr[i] == ':') { }else
                        an += arr[i];
                    }

                }    
            }
        }
        public void deleteElements(DataGridView remp, DataGridView operand)
        {
            int p = 0;
            int count = 0;
            string stroka12 = "";
            for (int i = 0; i < remp.RowCount-1; i++)
            {
                count = 0;
                stroka12 = "";
                bool tr = false;
                for (int z = 0; z < remp.RowCount-1; z++)
                {
                    if (remp[1, i].Value.ToString() == remp[1, z].Value.ToString())
                    {
                            for (int a = 0; a < operand.RowCount - 1; a++)
                            {
                                if (remp[1, i].Value.ToString() == operand[1, a].Value.ToString())
                                    tr = true;
                            }
                            count++;
                            stroka12 += remp[2, z].Value.ToString() + ";";
                    }
                }
                if (tr == false)
                {
                    operand.Rows.Add();
                    operand[0, p].Value = Convert.ToString(p+1);
                    operand[1, p].Value = remp[1, i].Value.ToString();
                    operand[2, p].Value = stroka12;
                    operand[3, p].Value = count;
                    p++;
                }
            }
        }
        public void deleteElements1(DataGridView remp, DataGridView operand)
        {

            int p = 0;
            int count = 0;
            string stroka12 = "";
            for (int i = 0; i < remp.RowCount - 1; i++)
            {
                count = 0;
                stroka12 = "";
                bool tr = false;
                for (int z = 0; z < remp.RowCount - 1; z++)
                {
                    if (remp[1, i].Value.ToString() == remp[1, z].Value.ToString())
                    {
                        for (int a = 0; a < operand.RowCount - 1; a++)
                        {
                            if (remp[1, i].Value.ToString() == operand[1, a].Value.ToString())
                                tr = true;
                        }
                        count++;
                        stroka12 += remp[2, z].Value.ToString() + ";";
                    }
                }
                if (tr == false)
                {
                    operand.Rows.Add();
                    operand[0, p].Value = Convert.ToString(p + 1);
                    operand[1, p].Value = remp[1, i].Value.ToString();
                    operand[2, p].Value = stroka12;
                    operand[3, p].Value = count;
                    p++;
                }
            }
        }
        public void sum1(DataGridView remp,TextBox result)
        {
            int count = 0;
            for (int i = 0; i < remp.RowCount - 1; i++)
            {
                count += Convert.ToInt32(remp[3, i].Value);
            }
            result.Text = Convert.ToString(count);

        }
        public void sum2(DataGridView remp, TextBox result)
        {
            int count = 0;
            for (int i = 0; i < remp.RowCount - 1; i++)
            {
                count += Convert.ToInt32(remp[3, i].Value);
            }
            result.Text = Convert.ToString(count);
        }
    }
}
