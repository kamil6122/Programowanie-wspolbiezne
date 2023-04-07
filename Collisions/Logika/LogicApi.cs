using Dane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        }
    }
}
