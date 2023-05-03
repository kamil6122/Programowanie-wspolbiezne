using Dane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public abstract class AbstractLogicApi
    {
        public static AbstractLogicApi Api(AbstractDataApi abstractDataApi = null)
        {
            return new LogicApi(abstractDataApi);
        }

        public abstract List<BallLogic> GetBalls();
        public abstract void StartUpdating(int width, int height, int amountOfBalls);
        public abstract void StopUpdating();
        public abstract bool IsUpdating();

        internal class LogicApi : AbstractLogicApi
        {
            private List<BallLogic> balls = new List<BallLogic>();
            private AbstractDataApi dataApi;

            public LogicApi(AbstractDataApi abstractDataApi = null) 
            {
                if (abstractDataApi == null)
                {
                    this.dataApi = AbstractDataApi.Api();
                }
                else
                {
                    this.dataApi = abstractDataApi;
                }
            }

            public override List<BallLogic> GetBalls()
            {
                return this.balls;
            }

            public override void StartUpdating(int width, int height, int amountOfBalls) 
            {
                this.dataApi.CreateField(width, height, amountOfBalls);
                foreach (Ball ball in this.dataApi.GetBalls())
                {
                    this.balls.Add(new BallLogic(ball));
                    ball.PropertyChanged += CheckCollision;
                }
            }

            public override void StopUpdating() 
            {
                this.dataApi.StopUpdating();
                this.balls.Clear();
            }

            public override bool IsUpdating() 
            {
                return dataApi.IsUpdating();
            }

            public void CheckCollision(object sender, PropertyChangedEventArgs e)
            {
                Ball ball = (Ball)sender;
                if (e.PropertyName == nameof(ball.X) || e.PropertyName == nameof(ball.Y))
                {
                    FieldCollision(ball);
                    BallCollision(ball);
                }
            }

            private void FieldCollision(Ball ball)
            {
                if (ball.X <= 0)
                {
                    ball.setDirection(1, ball.YDirection);
                }
                if (ball.X >= this.dataApi.Field.Width - ball.Radius)
                {
                    ball.setDirection(-1, ball.YDirection);
                }
                if (ball.Y <= 0)
                {
                    ball.setDirection(ball.XDirection, 1);
                }
                if (ball.Y >= this.dataApi.Field.Height - ball.Radius)
                {
                    ball.setDirection(ball.XDirection, -1);
                }
            }

            private void BallCollision(Ball ball)
            {
                foreach(Ball b in dataApi.GetBalls())
                {
                    if (b == ball)
                        continue;

                    if (Math.Pow(Math.Pow(ball.X - b.X, 2) + Math.Pow((ball.Y - b.Y), 2),0.5) < ball.Radius + b.Radius)
                    {
                        int mass1 = 5;
                        int mass2 = 5;

                        // ball 1 b 2
                        double dzielnik_1 = Math.Pow(Math.Pow((ball.X - b.X), 2) + Math.Pow((ball.Y - b.Y), 2),2);
                        double dzielnik_2 = Math.Pow(Math.Pow((b.X - ball.X), 2) + Math.Pow((b.Y - ball.Y), 2),2);
                        double przez_ile_1 = 2 * b.Mass / (ball.Mass + b.Mass) * ((ball.XDirection - b.XDirection) * (ball.X - b.X) * (ball.YDirection - b.YDirection) * (ball.Y - b.Y)) / dzielnik_1;
                        double przez_ile_2 = 2 * ball.Mass / (ball.Mass + b.Mass) * ((b.XDirection - ball.XDirection) * (b.X - ball.X) * (b.YDirection - ball.YDirection) * (b.Y - ball.Y)) / dzielnik_2;

                        double ballXDir = ball.XDirection - przez_ile_1 * (ball.X - b.X);
                        double ballYDir = ball.YDirection - przez_ile_1 * (ball.Y - b.Y);
                        double bXDir = ball.YDirection - przez_ile_1 * (ball.Y - b.Y);
                        double bYDir = ball.YDirection - przez_ile_1 * (ball.Y - b.Y);


                        ball.setDirection(ball.XDirection - przez_ile_1*(ball.X-b.X), ball.YDirection - przez_ile_1 * (ball.Y - b.Y));
                        b.setDirection(b.XDirection - przez_ile_2*(b.X-ball.X), b.YDirection - przez_ile_2 * (b.Y - ball.Y));
                        if (ball.XDirection > 1.5) ball.setDirection(3, ball.YDirection);
                        if (ball.YDirection > 1.5) ball.setDirection(ball.XDirection, 3);
                        if (b.XDirection > 1.5) b.setDirection(3, b.YDirection);
                        if (b.YDirection > 1.5) b.setDirection(b.XDirection, 3);

                        Debug.WriteLine(ball.XDirection);
                        Debug.WriteLine(ball.YDirection);
                    }
                }
            }
        }
    }
}
