
Console.WriteLine(BouncingBall.bouncingBall(3.0, 0.66, 1.5));
Console.WriteLine(BouncingBall.bouncingBall(30.0, 0.66, 1.5));


public class BouncingBall
{

    public static int bouncingBall(double h, double bounce, double window)
    {
        if (h > 0 && 0 < bounce && bounce < 1 && window < h)
        {
            int count = 1;
            h *= bounce;
            while (h > window)
            {
                count += 2;
                h *= bounce;
            }
            return count;
        }
        else
        {
            return -1;
        }
    }
}