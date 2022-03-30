using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BondCalculator
{
    class BondCalc
    {
        static void Main(string[] args)
        {
            
            //double[] tolerance = new double[n];
            double[] cashFlows;
            double[] datesOfCF;
            double[] discFactors;
            double couponRate;


            double bondPrice = 0;
            Func<double, double> f;

            //Problem #6 (i),
            Console.WriteLine("Problem #6 (i)");
            Console.WriteLine("Find a price of a two year semiannual coupon bond with coupon rate 7%.");
            int m = 4;
            f = ZeroCurveRate_6;
            couponRate = 0.07;
            datesOfCF = new double[]{0.5, 1.0, 1.5, 2.0};
            DisplayTimeIntervals(datesOfCF);
            cashFlows = GetCashFlows(m, couponRate, 2);
            discFactors = DiscFactorCalculator(datesOfCF, f);
            bondPrice = BondCalculator(discFactors, cashFlows);
            DisplayBondPrice(bondPrice);

            //Console.WriteLine("Bond price = " + bondPrice.ToString());
            Console.WriteLine();

            //Problem #6 (ii),
            Console.WriteLine("Problem #6 (ii)");
            Console.WriteLine("Find a price of a semiannual coupon bond with coupon rate 7% and maturity in 19 months.");
            m = 4;
            double[] dates_6ii = new double []{(double)(1.0/12.0), (double)(7.0/12.0), (double)(13.0/12.0), (double)(19.0/12.0)};
            DisplayTimeIntervals(dates_6ii);
            discFactors = DiscFactorCalculator(dates_6ii, f);
            bondPrice = BondCalculator(discFactors, cashFlows);
            DisplayBondPrice(bondPrice);
            //Console.WriteLine("Bond price = " + bondPrice.ToString());
            Console.WriteLine();


            //problem #7
            Console.WriteLine("Problem #7");
            Console.WriteLine("Find a value of a 19-month bond with a coupon rate 4% and face value $100, ");
            Console.WriteLine("if the bond is an annual coupon bond.");
            m = 2;
            f = ZeroCurveRate_7;
            couponRate = 0.04;
            double[] dates_7a = new double[] { (7.0/12.0), (19.0/12.0)};
            DisplayTimeIntervals(dates_7a);
            cashFlows = GetCashFlows(m, couponRate, 1);
            discFactors = DiscFactorCalculator(dates_7a, f);
            bondPrice = BondCalculator(discFactors, cashFlows);
            DisplayBondPrice(bondPrice);
            //Console.WriteLine("Bond price = " + bondPrice.ToString());
            Console.WriteLine();

            Console.WriteLine("Find a value of a 19-month bond with a coupon rate 4% and face value $100, ");
            Console.WriteLine("if the bond is a semiannual coupon bond.");
            m = 4;
            f = ZeroCurveRate_7;
            couponRate = 0.04;
            cashFlows = GetCashFlows(m, couponRate, 2);
            DisplayTimeIntervals(dates_6ii);
            discFactors = DiscFactorCalculator(dates_6ii, f);
            bondPrice = BondCalculator(discFactors, cashFlows);
            DisplayBondPrice(bondPrice);
            //Console.WriteLine("Bond price = " + bondPrice.ToString());
            Console.WriteLine();

            Console.WriteLine("Find a value of a 19-month bond with a coupon rate 4% and face value $100, ");
            Console.WriteLine("if the bond is a quarterly coupon bond.");
            m = 7;
            f = ZeroCurveRate_7;
            couponRate = 0.04;
            double[] dates_7q = new double[] {(1.0/12.0), (4.0/12.0), (7.0/12.0), (10.0/12.0), (13.0/12.0),(16.0/12.0), (19.0/12.0) };
            DisplayTimeIntervals(dates_7q);
            cashFlows = GetCashFlows(m, couponRate, 4);
            discFactors = DiscFactorCalculator(dates_7q, f);
            bondPrice = BondCalculator(discFactors, cashFlows);
            DisplayBondPrice(bondPrice);
            //Console.WriteLine("Bond price = " + bondPrice.ToString());
            Console.WriteLine();


              //Problem #8
            /*  
              Console.WriteLine("Problem #8. Book example. Test.");
              m = 4;
              double yield = 0.065;
              double[] dates_8 = new double[] { (double)(2.0/12.0), (double)(8.0 / 12.0), (double)(14.0 / 12.0), (double)(20.0 / 12.0) };
              double[] cf_8 = GetCashFlows(m, 0.06, 2);
              bondPrice = YieldBondCalculator(dates_8, cf_8, yield);
              double duration = GetDuration(dates_8, cf_8, yield);
              duration = duration / bondPrice;
              double convexity = GetConvexity(dates_8, cf_8, yield);
              convexity = convexity / bondPrice;*/

            

             Console.WriteLine();
             Console.WriteLine();
             Console.WriteLine("Problem #8");
             Console.WriteLine();
             m = 4;
             double yield = 0.025;
             double[] dates_8 = new double[] { (double)(1.0 / 12.0), (double)(7.0 / 12.0), (double)(13.0 / 12.0), (double)(19.0 / 12.0) };
             DisplayTimeIntervals(dates_8);
             double[] cf_8 = GetCashFlows(m, 0.04, 2);
             bondPrice = YieldBondCalculator(dates_8, cf_8, yield);
             double duration = GetDuration(dates_8, cf_8, yield);
             duration = duration / bondPrice;
             double convexity = GetConvexity(dates_8, cf_8, yield);
             convexity = convexity / bondPrice;
             Console.WriteLine("Bond price = " + Math.Round(bondPrice, 9));
             Console.WriteLine("Bond duration = " + Math.Round(duration, 12));
             Console.WriteLine("Bond convexity = " + Math.Round(convexity, 12));
           

            //Problem #9
             Console.WriteLine();
            Console.WriteLine("Problem #9");
            Console.WriteLine("Given instantaneous curve rate r(t) compute 6-month, 1-year, 18-month discount factors with 6 decimal degits of accurecy.");
            double[] toleranceA = new double[] {10e-6, 10e-6, 10e-6, 10e-8 };
            f = InstantaneousRateCurve_9;
            m = 4;
            double x1 = 0.0; 
            double x2 = 0.5;
            double [] df_9 = new double[4];
            //NumericalIntegration integrator = new NumericalIntegration(x1, x2, m, toleranceA, f);
            double iSum = NumericalIntegration.ConvergenceMachine(f, 10e-12, x1, x2, m);
            //double iSum = NumericalIntegration.ConvergenceMachine(f, toleranceA[0], x1, x2, m);
            df_9[0] = Math.Exp(-iSum);
            Console.WriteLine("6 month discount factor: " + Math.Round(df_9[0], 12));
            Console.WriteLine();

            x2 = 1.0;
            //iSum=  NumericalIntegration.ConvergenceMachine(f, toleranceA[1], x1, x2, m);
            iSum = NumericalIntegration.ConvergenceMachine(f, 10e-12, x1, x2, m);
            df_9[1] = Math.Exp(-iSum); 
            Console.WriteLine("1 year discount factor: " + Math.Round(df_9[1], 12));
            Console.WriteLine();

            x2 = 1.5;
            //iSum = NumericalIntegration.ConvergenceMachine(f, toleranceA[2], x1, x2, m);
            iSum = NumericalIntegration.ConvergenceMachine(f, 10e-12, x1, x2, m);
            df_9[2] = Math.Exp(-(iSum));
            Console.WriteLine("18 months discount factor: " + Math.Round(df_9[2], 12));
            Console.WriteLine();

            x2 = 2.0;
            //iSum = NumericalIntegration.ConvergenceMachine(f, toleranceA[3], x1, x2, m);
            iSum = NumericalIntegration.ConvergenceMachine(f, 10e-12, x1, x2, m);
            df_9[3] = Math.Exp(-(iSum));
            Console.WriteLine("2 year discount factor :" + Math.Round(df_9[3], 12));
            Console.WriteLine("");
            double[] cf_9 = GetCashFlows(m, 0.05, 2);
            bondPrice = BondCalculator(df_9, cf_9);
            DisplayBondPrice(bondPrice);   

            Console.WriteLine();
        }

        public static double BondCalculator(double[] df, double[] cf)
        {
            double price = 0 ;
            for(int i = 0; i< cf.Length; i++)
                price += cf[i]*df[i];
            return price;
        }

        public static double YieldBondCalculator(double[] t, double[] cf, double y) 
        {
            double sum = 0.0;
            for (int i = 0; i < cf.Length; i++)
            {
                sum += cf[i] * Math.Exp(-(y * t[i]));
            }

            return sum;
        }

        public static double GetConvexity(double[] t, double[] cf, double y)
        {
            double sum = 0.0;
            for (int i = 0; i < cf.Length; i++)
            {
                sum += t[i] * t[i] * cf[i] * Math.Exp(-(y * t[i]));
            }

            return sum;
        }

        public static double GetDuration(double[] t, double[] cf, double y)
        {
            double sum = 0.0;
            for (int i = 0; i < cf.Length; i++)
            {
                sum += t[i]*cf[i] * Math.Exp(-(y * t[i]));
            }

            return sum;
        }

        public static double[] DiscFactorCalculator(double[] dates, Func<double, double> f)
        { 
            double [] df = new double[dates.Length];

            for(int i=0; i< dates.Length; i++)
            {
                df[i]= Math.Exp(-(f(dates[i])*dates[i]));
                Console.WriteLine("Discount Factor {0}: {1}",(i+1).ToString(), Math.Round(df[i], 12));
            }
            return df;
        }

        public static double[] GetCashFlows(int m, double cRate, int f)
        {//f like frequency
            double[] cf = new double[m];
            Console.Write("Cashflows: ");
            for (int i = 0; i < (m-1); i++)
            {
                cf[i] = cRate / f*100;
                Console.Write(cf[i].ToString() + ", ");
            }
            cf[m-1] = 100 + (cRate / f * 100);
            Console.Write(cf[m-1].ToString());
            Console.WriteLine();

            return cf;
        }

        public static double ZeroCurveRate_6(double t) 
        {
            return 0.05 + 0.005 * Math.Sqrt(1 + t);
        }

        public static double ZeroCurveRate_7(double t)
        {
            return 0.02 + (t / (200.0 - t));
        }

        public static double InstantaneousRateCurve_9(double t) 
        {
            return 0.05 / (1 + 2 * Math.Exp(-(1 + t)*(1 + t)));
        }

        public static void DisplayTimeIntervals(double[] t)
        {
            for (int i = 0; i< t.Length; i++)
            {
                Console.WriteLine("t{0} = {1}", (i+1), t[i]);
            }
        }

        public static void DisplayBondPrice(double b) 
        {
            Console.WriteLine("Bond Price = {0}", Math.Round(b, 9));
        }


    }
}
