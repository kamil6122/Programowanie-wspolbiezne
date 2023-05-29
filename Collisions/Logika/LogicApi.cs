using Dane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
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
            private readonly object locked = new object();

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

            public double distance(Ball ball1, Ball ball2)
            {
                double x = Math.Pow(ball1.X - ball2.X, 2);
                double y = Math.Pow(ball1.Y - ball2.Y, 2);
                return Math.Pow(x + y, 0.5);
            }

            private void FieldCollision(Ball ball)
            {
               
                if (ball.X < 0)
                {
                    ball.setDirection(Math.Abs(ball.XDirection), ball.YDirection);
                }
                if (ball.X > this.dataApi.Field.Width - ball.Radius)
                {
                    ball.setDirection(-Math.Abs(ball.XDirection), ball.YDirection);
                }
                if (ball.Y < 0)
                {
                    ball.setDirection(ball.XDirection, Math.Abs(ball.YDirection));
                }
                if (ball.Y + ball.Radius > this.dataApi.Field.Height)
                {
                    ball.setDirection(ball.XDirection, -Math.Abs(ball.YDirection));
                }
            }

            private void BallCollision(Ball ball)
            {

                foreach(Ball b in dataApi.GetBalls())
                {
                    if (b == ball)
                        continue;

                    double ballCenterX = ball.X + ball.Radius / 2;
                    double ballCenterY = ball.Y + ball.Radius / 2;
                    double bCenterX = b.X + b.Radius / 2;
                    double bCenterY = b.Y + b.Radius / 2;

                    


                    if (Math.Pow(Math.Pow((ballCenterX + ball.XDirection) - (bCenterX + b.XDirection), 2) + Math.Pow(((ballCenterY + ball.YDirection) - (bCenterY + b.YDirection)), 2),0.5) < ((ball.Radius / 2) + (b.Radius / 2)))
                    {
                        double v = ((b.XDirection * (b.Mass - ball.Mass) + (2 * ball.Mass * ball.XDirection)) / (b.Mass + ball.Mass));
                        double ballXDir = ((ball.XDirection * (ball.Mass - b.Mass) + (2 * b.Mass * b.XDirection)) / (b.Mass + ball.Mass));
                        double bXDir = v;

                        v = ((b.YDirection * (b.Mass - ball.Mass) + (2 * ball.Mass * ball.YDirection)) / (b.Mass + ball.Mass));
                        double ballYDir = ((ball.YDirection * (ball.Mass - b.Mass) + (2 * b.Mass * b.YDirection)) / (b.Mass + ball.Mass));
                        double bYDir = v;

                        lock (locked)
                        {
                            b.setDirection(bXDir, bYDir);
                            ball.setDirection(ballXDir, ballYDir);
                        }
                                                                     
                    }
                }
            }
        }
    }
}
