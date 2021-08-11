namespace Stardate
{
    public class Jdc
    {
        public const float jdcBaseDay = 40587.0F;     // Modified Julian Date at January 1, 1970
        public const float jdcModifier = 2400000.5F; // Amount by which MJD is modified from JD

        public static DateTime JdcToInternal(float jdc, JdcFormat format)
        {
            throw new NotImplementedException();
            switch (format)
            {
                case JdcFormat.Full:
                    break;
            }
        }
    }
}
