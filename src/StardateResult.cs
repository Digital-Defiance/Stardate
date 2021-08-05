namespace Stardate
{
    using System;
    public struct StardateString
    {
        public long? Issue;
        public float Stardate;

        public StardateString(string stardate)
        {
            if (stardate.StartsWith('['))
            {
                var parts = stardate.Split(new char[] { '[', ']' });
                if (parts.Length != 4)
                {
                    throw new Exception("Unexpected string sequence");

                }

                this.Issue = long.Parse(parts[1]);
                this.Stardate = float.Parse(parts[3]);
            }
            else
            {
                this.Issue = null;
                this.Stardate = float.Parse(stardate);
            }
        }
    }
}
