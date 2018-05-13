using System.Windows.Media;

namespace TetrisEngine
{
    //here are just hardcoded shapes with colors
    public static class Shapes
    {
        public static Shape Get2x2()
        {
            Shape res = new Shape(2);
            res.Color = Colors.Chocolate;
            res.Map[0, 0] = true;
            res.Map[0, 1] = true;
            res.Map[1, 1] = true;
            res.Map[1, 0] = true;
            return res;
        }

        public static Shape GetL()
        {
            Shape res = new Shape(3);
            res.Color = Colors.Yellow;

            res.Map[0, 0] = true;
            res.Map[0, 1] = true;
            res.Map[0, 2] = true;
            res.Map[1, 0] = true;
            return res;
        }

        public static Shape GetL2()
        {
            Shape res = new Shape(3);
            res.Color = Colors.BlueViolet;

            res.Map[0, 0] = true;
            res.Map[0, 1] = true;
            res.Map[0, 2] = true;
            res.Map[1, 2] = true;
            return res;
        }

        public static Shape GetZ()
        {
            Shape res = new Shape(3);
            res.Color = Colors.Red;
            res.Map[0, 0] = true;
            res.Map[0, 1] = true;
            res.Map[1, 1] = true;
            res.Map[1, 2] = true;
            return res;
        }

        public static Shape GetZ2()
        {
            var res = new Shape(3);
            res.Color = Colors.Chartreuse;
            res.Map[0, 1] = true;
            res.Map[1, 0] = true;
            res.Map[1, 1] = true;
            res.Map[0, 2] = true;
            return res;
        }

        public static Shape GetK()
        {
            Shape res = new Shape(3);
            res.Color = Colors.Salmon;
            res.Map[0, 0] = true;
            res.Map[0, 1] = true;
            res.Map[0, 2] = true;
            res.Map[1, 1] = true;
            return res;
        }

        public static Shape Get4line()
        {
            Shape res = new Shape(4);
            res.Color = Colors.Gold;
            res.Map[0, 0] = true;
            res.Map[0, 1] = true;
            res.Map[0, 2] = true;
            res.Map[0, 3] = true;
            return res;

        }

    }
}