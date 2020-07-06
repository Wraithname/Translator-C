using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Leksema
{
    
    class Class1
    {
        public static string str;
        List<string> identificator = new List<string>();
        List<string> literal = new List<string>();
        List<string> delimiter = new List<string>();
        private void analysis(string str)
        {
            char[] delim = new char[] {'=','+', '-', '*', '/', '<', '>', '!', ':', ';', ',', '(', ')', '|', '%', '&', '^', '`', '$', '"', '~', '@', '#', '?', '_', '[', ']', '{', '}' };
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                    identificator.Add(Convert.ToString(str[i]));
                if (str[i] >= '0' && str[i] <= '9')
                    literal.Add(Convert.ToString(str[i]));
                for(int j=0;j<delim.Length;j++)
                if (str[i]==delim[j])
                    delimiter.Add(Convert.ToString(str[i]));
                if (str[i] == ' ')
                    i++;
            }
        }
    }
}
