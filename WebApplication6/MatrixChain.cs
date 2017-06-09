using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Model
{
    public class MatrixChain
    {

 
        public static string multiplyOrder(int[] p)
        {
            string res="";
            int n = p.Length-1;
            int[,] dp = new int[n + 1,n + 1];

            for (int i = 1; i <= n; i++)
            {
                dp[i,i] = 0;
            }

            for (int l = 2; l <= n; l++)
            {
                for (int i = 1; i <= n - l + 1; i++)
                {
                    int j = i + l - 1;
                    dp[i,j] = 999999999;
                    res += "f(" + i + "," + j + ")=min(";
                        for (int k = i; k <= j - 1; k++)
                    {

                        dp[i,j] = Math.Min(dp[i,j],  dp[i,k] + dp[k + 1,j] + p[i - 1] * p[k] * p[j]);
                        //  res += dp[i, k].ToString();
                        res += "f("+ i.ToString()+ ","+ k.ToString()+")";

                        res += "+f(" + (k + 1).ToString() + "," + j.ToString()+")";
                        res += "+" + p[i - 1].ToString();
                        res += "+" + p[k].ToString();
                        res += "+" + p[j].ToString();

                        res += "=" + (dp[i, k] + dp[k + 1, j] + p[i - 1] * p[k] * p[j]).ToString();
                        if (k!=j-1)
                        
                            res +=  "&nbsp;&nbsp; <b>;</b>  &nbsp;&nbsp; ";

                    }
                    res += ")&nbsp;&nbsp;=" + dp[i, j];
                    res += "<br>";
                }
            }
            res += dp[1, n].ToString();
            return res;
        }




    }



}