using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClass
{
    class Time
    {
        int hours, minutes, seconds, hundreths;

        public Time(int hours,int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = 0;
            this.hundreths = 0;
            if (minutes >= 60)
            {
                this.hours += minutes / 60;
                this.minutes = minutes % 60;
            }
            this.seconds = 0;
            this.hundreths = 0;
        }

        public Time(int hours, int minutes,int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.hundreths = 0;
            if (minutes >= 60)
            {
                this.hours += minutes / 60;
                this.minutes = minutes % 60;
            }
            if (seconds >= 60)
            {
                this.minutes += seconds / 60;
                this.seconds = seconds % 60;
            }
            this.hundreths = 0;
        }

        public Time(int hours, int minutes,int seconds,int hundreths)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.hundreths = hundreths;
            if (minutes >= 60)
            {
                this.hours += minutes / 60;
                this.minutes = minutes % 60;
            }
            if (seconds >= 60)
            {
                this.minutes += seconds / 60;
                this.seconds = seconds % 60;
            }
            if (hundreths >= 100)
            {
                this.seconds += hundreths / 100;
                this.hundreths = hundreths % 100;
            }
        }

        public Time(string input)
        {
            string[] data = input.Split(':');
            int hours = int.Parse(data[0]);
            int minutes = int.Parse(data[1]);
            int seconds = int.Parse(data[2]);
            int hundreths = int.Parse(data[3]);

            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.hundreths = hundreths;
            if (minutes >= 60)
            {
                this.hours += minutes / 60;
                this.minutes = minutes % 60;
            }
            if (seconds >= 60)
            {
                this.minutes += seconds / 60;
                this.seconds = seconds % 60;
            }
            if (hundreths >= 100)
            {
                this.seconds += hundreths / 100;
                this.hundreths = hundreths % 100;
            }
        }

        public void normalize()
        {
            if (this.hundreths < 0)
            {
                this.seconds -= 1;
                this.hundreths += 100;
            }
            if (this.seconds < 0)
            {
                this.minutes -= 1;
                this.seconds += 60;
            }
            if (this.minutes < 0)
            {
                this.hours -= 1;
                this.minutes += 60;
            }
        }

        public bool Equals(Time r)
        {
            return this.hours == r.hours && this.minutes == r.minutes && this.seconds == r.seconds && this.hundreths == r.hundreths;
        }

        private Time add(Time a)
        {
            return new Time(this.hours + a.hours, this.minutes + a.minutes, this.seconds + a.seconds, this.hundreths + a.hundreths);
        }

        private Time substract(Time a)
        {
            Time time = new Time(this.hours - a.hours, this.minutes - a.minutes, this.seconds - a.seconds, this.hundreths - a.hundreths);
            time.normalize();
            return time;
        }

        private Comparison compare(Time r)
        {
            if (this.Equals(r))
                return Comparison.Equal;
            if (this.hours < r.hours)
            {
                return Comparison.Greater;
            } else if(this.hours > r.hours)
            {
                return Comparison.Less;
            } else
            {
                if (this.minutes < r.minutes)
                {
                    return Comparison.Greater;
                }
                else if (this.minutes > r.minutes)
                {
                    return Comparison.Less;
                }
                else
                {
                    if (this.seconds < r.seconds)
                    {
                        return Comparison.Greater;
                    }
                    else if (this.seconds > r.seconds)
                    {
                        return Comparison.Less;
                    }
                    else
                    {
                        if (this.hundreths < r.hundreths)
                        {
                            return Comparison.Greater;
                        }
                        else if (this.hundreths > r.hundreths)
                        {
                            return Comparison.Less;
                        }
                    }
                }
            }
            return Comparison.Equal;
        }

        public enum Comparison
        {
            Equal, Greater, Less
        }

        public static bool operator <(Time a, Time b)
        {
            return a.compare(b) == Comparison.Greater;
        }

        public static bool operator >(Time a, Time b)
        {
            return a.compare(b) == Comparison.Less;
        }

        public static bool operator >=(Time a, Time b)
        {
            Comparison c = a.compare(b);
            return c == Comparison.Equal || c == Comparison.Less;
        }
        public static bool operator <=(Time a, Time b)
        {
            Comparison c = a.compare(b);
            return c == Comparison.Equal || c == Comparison.Greater;
        }

        public static bool operator ==(Time a, Time b)
        {
            return a.compare(b) == Comparison.Equal;
        }

        public static bool operator !=(Time a, Time b)
        {
            return a.compare(b) != Comparison.Equal;
        }

        public static Time operator +(Time a, Time b)
        {
            return a.add(b);
        }

        public static Time operator -(Time a, Time b)
        {
            return a.substract(b);
        }

        public static implicit operator string(Time r)
        {
            return r.toString();
        }

        public string toString()
        {
            return $"{this.hours}:{this.minutes}:{this.seconds}:{this.hundreths}";
        }
    }
}
