using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offner_D
{
    class CodeV
    {
        public static string Part1 = "LEN NEW\n";
        public static string Part2(string x)
        {
            string co="";


            for (int i = 2; i <= int.Parse(x); i++)
            {
                co = co + "\n" + "IN CV_MACRO:inswl " + (i-1) +"+1";
            }

            /*   switch (x)
                   {
                   case "1":
                       co = "\n";
                       break;
                   case "5":
                       co = "IN CV_MACRO:inswl 1+1\nIN CV_MACRO:inswl 2 +1\nIN CV_MACRO:inswl 3 +1\nIN CV_MACRO:inswl 4 +1\n";
                       break;
                   default:
                       Console.WriteLine("沒輸入呀87");
                       break;
               }*/

            return co+"\n";
        }

        public static string Part3(string sh, string lo,string x)
        {
            string co = "失敗";
            int S = int.Parse(sh);
            int L = int.Parse(lo);
            int X = int.Parse(x);
            int sp = 0;
            int M = L;
            int Mi = 1;


            if (X > 1)
            {
                 M = (S + L) / 2;
                Mi = (X/2)+1;
                sp = (L - S) / (X - 1);
            }
         
            int wave_temp=L;
            co ="WL W1 "+lo;
            for (int i=2; i<=X;i++)
            {
                wave_temp = wave_temp - sp;
                co = co+"\n"+"WL W"+(i)+" " + wave_temp.ToString();
             }
            return co+ "\nCLS WVL\nREF "+Mi+"\n";
        }

        public static string Part4(string Fno,string th1,string th2,string th3,string th4,string r1,string r2,string r3, string degree1, string degree2, string degree3)
        {
            string co_f = "FNO "+Fno+ "\nDIM M\nins s1\nins s3\nRMD S1 REFL\nRMD  S2 REFL\nRMD S3 REFL\n";
            string co_r = "RDY  S1 "+r1+ "\nRDY  S2 "+r2+ "\nRDY  S3 "+r3+ "\nRDY  S4 0\n";
            string co_t = "THI  SO "+th1+ "\nTHI  S1 "+th2+ "\nTHI  S2 "+th3+ "\nTHI  S3 "+th4+ "\nTHI  S4 0\n";
            string co_d = "ben s1; ade s1 "+ degree1+ "\nben s2; ade s2 " + degree2+ "\nben s3; ade s3 " + degree3+"\n";

            return co_f+ co_r+ co_t+ co_d;
        }


        public static string Part5(string grating_sp)
        {
            string co = "DIF S2 GRT\nGRO S2 1\nGRS S2 "+grating_sp+"\n";
            return co;
        }

        public static string Part6(string x)
        {
            string co = "\n\nVIE\nSSI  0"+"\nRAT DEF;RAT COL RED; FAN W1 0 11";
            // Light_Color_Enum color = new Light_Color_Enum;
            string[] color = new string[] { "RED", "GRE", "BLU", "MAG", "YEL", "RED", "GRE", "BLU", "MAG", "YEL", "RED", "GRE", "BLU", "MAG", "YEL", "RED", "GRE", "BLU", "MAG", "YEL" };
            //string[] color = new string{ "RED", "GRE", "BLU", "MAG", "YEL" };


            for (int i = 2; i <= int.Parse(x); i++)
            {
                co = co + "\n" + "RAT DEF; RAT COL " + color[i-1]+ "; FAN W" +i+" 0 11";
            }
            return co + "\nGO\n";
        }


    }












    }

