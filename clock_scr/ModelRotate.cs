using System.Linq;
using System.Windows.Media.Media3D;

namespace clock_scr
{
    public class ModelRotate
    {
        private static readonly double AngleDelta = 5.0;

        public static void Rotate(Model3D model, Vector3D axis)
        {
            var transform = model.Transform as Transform3DGroup;
            if (transform == null)
            {
                transform = new Transform3DGroup();
                model.Transform = transform;
            }

            var rotation = transform.Children.OfType<RotateTransform3D>().FirstOrDefault(r =>
            {
                var axisRotation = r.Rotation as AxisAngleRotation3D;
                return axisRotation != null && axisRotation.Axis.Equals(axis);
            });

            if (rotation == null)
            {
                rotation = new RotateTransform3D(new AxisAngleRotation3D(axis, AngleDelta));
                transform.Children.Add(rotation);
            }
            else
            {
                var axisRotation = rotation.Rotation as AxisAngleRotation3D;
                if (axisRotation != null)
                {
                    axisRotation.Angle += AngleDelta;
                }
            }
        }

        public static void RotateAroundCenter(Model3D model, Vector3D axis)
        {
            var transform = model.Transform as Transform3DGroup;
            if (transform == null)
            {
                transform = new Transform3DGroup();
                model.Transform = transform;
            }

            Rect3D bounds = model.Bounds;
            Point3D center = new Point3D(
                bounds.X + bounds.SizeX / 2.0,
                bounds.Y + bounds.SizeY / 2.0,
                bounds.Z + bounds.SizeZ / 2.0);

            var rotation = transform.Children.OfType<RotateTransform3D>().FirstOrDefault(r =>
            {
                var axisRotation = r.Rotation as AxisAngleRotation3D;
                return axisRotation != null
                    && axisRotation.Axis.Equals(axis)
                    && r.CenterX == center.X
                    && r.CenterY == center.Y
                    && r.CenterZ == center.Z;
            });

            if (rotation == null)
            {
                rotation = new RotateTransform3D(
                    new AxisAngleRotation3D(axis, AngleDelta),
                    center);

                transform.Children.Add(rotation);
            }
            else
            {
                var axisRotation = rotation.Rotation as AxisAngleRotation3D;
                if (axisRotation != null)
                {
                    axisRotation.Angle += AngleDelta;
                }
            }
        }
    }
}