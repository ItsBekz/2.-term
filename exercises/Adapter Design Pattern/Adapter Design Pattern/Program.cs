
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace AdapterDesignPattern
{
    public class Adapter
    {
        public static void Main(string[] args)
        {
            ITarget target =
            new Adaptor(
            new Adaptee());

            String svar = target.Request();
            Console.WriteLine(svar);

            BrugerMath bm = new BrugerMath(null);
            double a, b;
            Console.WriteLine("Give first value: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Give second value: ");
            b = Convert.ToDouble(Console.ReadLine());
            
            double svar2 = bm.leagSammen(a, b);
            Console.WriteLine("This is math: {0}", svar2);

            BrugerMath bm2 = new BrugerMath(new FrenchMath());
            double svar3 = bm2.leagSammen(a, b);
            Console.WriteLine("This is french math: {0}", svar3);

        }

        interface ITarget
        {
            string Request();
        }

        class Adaptor : ITarget
        {
            Adaptee adpte;
            public Adaptor(Adaptee adpte)
            {
                this.adpte = adpte;
            }

            public string Request()
            {
                return adpte.NoRequest();
            }
        }

        class Adaptee
        {
            public string NoRequest()
            {
                return "Jeg er ikke Request metoden.";
            }
        }

        interface IAdaptorMath
        {
            double leagSammen(double a, double b);
        }

        class BrugerMath : IAdaptorMath
        {
            Math math = new Math();
            FrenchMath fMath;
            bool check = false;
            public BrugerMath(FrenchMath fMath)
            {
                if(fMath == null)
                {
                    check = false;
                }
                else
                {
                    this.fMath = fMath;
                    check = true;
                }
            }

            public double leagSammen(double a, double b)
            {
                double result = 0;
                if(check)
                {
                    result = fMath.lePlus(a, b);
                }
                else
                {
                    result = math.Plus(a, b);
                }
                return result;
            }
        }

        class Math
        {
            public double Plus(double a, double b)
            {
                return a + b;
            }
        }
        class FrenchMath
        {
            public double lePlus(double a, double b)
            {
                return a + b + 10;
            }
        }

    }
}