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
                //ballCenterX = ball.X + ball.Radius / 2;
                //ballCenterY = ball.Y + ball.Radius / 2;
                if (ball.X < 0)
                {
                    ball.setDirection(Math.Abs(ball.XDirection), ball.YDirection);
                    //ball.changePosition(ball.Radius, ball.Y);
                }
                if (ball.X > this.dataApi.Field.Width - ball.Radius)
                {
                    ball.setDirection(-Math.Abs(ball.XDirection), ball.YDirection);
                    //ball.changePosition(this.dataApi.Field.Width - ball.Radius, ball.Y);
                }
                if (ball.Y < 0)
                {
                    ball.setDirection(ball.XDirection, Math.Abs(ball.YDirection));
                    //ball.changePosition(ball.X, ball.Radius);
                }
                if (ball.Y + ball.Radius > this.dataApi.Field.Height)
                {
                    ball.setDirection(ball.XDirection, -Math.Abs(ball.YDirection));
                    //ball.changePosition(ball.X, this.dataApi.Field.Height - ball.Radius - 2);
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

                        // ball 1 b 2
                        double ballCenterX = ball.X + ball.Radius / 2;
                        double ballCenterY = ball.Y + ball.Radius / 2;
                        double bCenterX = b.X + b.Radius / 2;
                        double bCenterY = b.Y + b.Radius / 2;
                        double dzielnik_1 = Math.Pow(Math.Pow((ballCenterX - bCenterX), 2) + Math.Pow((ballCenterY - bCenterY), 2),2);
                        double dzielnik_2 = Math.Pow(Math.Pow((bCenterX - ballCenterX), 2) + Math.Pow((bCenterY - ballCenterY), 2),2);
                        double przez_ile_1 = 2 * b.Mass / (ball.Mass + b.Mass) * ((ball.XDirection - b.XDirection) * (ball.X - b.X) * (ball.YDirection - b.YDirection) * (ball.Y - b.Y)) / dzielnik_1;
                        double przez_ile_2 = 2 * ball.Mass / (ball.Mass + b.Mass) * ((b.XDirection - ball.XDirection) * (b.X - ball.X) * (b.YDirection - ball.YDirection) * (b.Y - ball.Y)) / dzielnik_2;

                        double ballXDir = ball.XDirection - przez_ile_1 * (ballCenterX - bCenterX);
                        double ballYDir = ball.YDirection - przez_ile_1 * (ballCenterY - bCenterY);
                        double bXDir = b.XDirection - przez_ile_2 * (bCenterX - ballCenterX);
                        double bYDir = b.YDirection - przez_ile_2 * (bCenterY - ballCenterY);


                        ball.setDirection( (ballXDir > 1.5) ? 1.5 : (ballXDir < -1.5) ? -1.5 : ballXDir
                                            ,(ballYDir > 1.5) ? 1.5 : (ballYDir < -1.5) ? -1.5 : ballYDir);

                        b.setDirection((bXDir > 1.5) ? 1.5 : (bXDir < -1.5) ? -1.5 : bXDir
                                        ,(bYDir > 1.5) ? 1.5 : (bYDir < -1.5) ? -1.5 : bYDir);
                        

                        
                    }
                }
            }
        }
    }
}
