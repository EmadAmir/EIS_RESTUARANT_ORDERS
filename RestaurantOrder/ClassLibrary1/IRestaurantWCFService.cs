﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestaurantWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestaurantServiceWCF" in both code and config file together.
    [ServiceContract]
    public interface IRestaurantWCFService
    {
        //[OperationContract]
        //string GetMessage(string name);
        [OperationContract]
        void SaveDetails(Restaurant Restaurant);
    }
}
