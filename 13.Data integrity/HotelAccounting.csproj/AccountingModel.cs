using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting {
    class AccountingModel: ModelBase {
        private double price;
        private double nightsCount;
        private double discount;
        private double total;

        public double Price {
            get {
                return price;
            }
            set {
                Notify(nameof(Price));
                if(value < 0)
                    throw new ArgumentOutOfRangeException("value");
                price = value;
                Notify(nameof(Total));
                total = price * nightsCount * (1 - discount / 100);
            }
        }
        public double NightsCount {
            get {
                return nightsCount;
            }
            set {
                Notify(nameof(NightsCount));
                if(value < 1)
                    throw new ArgumentOutOfRangeException("value");
                nightsCount = value;
                Notify(nameof(Total));
                total = price * nightsCount * (1 - discount / 100);
            }
        }
        public double Discount {
            get {
                return discount;
            }
            set {
                Notify(nameof(Discount));
                if(value > 100)
                    throw new ArgumentOutOfRangeException("value");
                discount = value;
                Notify(nameof(Total));
                total = price * nightsCount * (1 - discount / 100);
            }
        }
        public double Total {
            get {
                return total;
            }
            set {
                Notify(nameof(Total));
                if(value < 0)
                    throw new ArgumentOutOfRangeException("value");
                total = value;
                Notify(nameof(Discount));
                discount = 100 * (1 - total / (price * nightsCount));
            }
        }
    }
}