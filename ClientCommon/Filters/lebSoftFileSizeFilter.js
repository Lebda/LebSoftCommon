var lebsoftRoundToTwo = function roundToTwo(num)
{
    return +(Math.round(num + "e+2") + "e-2");
}

angular.module("lebSoftFiltersApplicationModule")
    .filter("lebSoftFileSizeFilter", function ()
    {
        return function (value)
        {
            if (angular.isNumber(value))
            {
                if (value < 1000)
                {
                    return lebsoftRoundToTwo(value).toString() + "B";B
                }
                else if (value < 100000)
                {
                    return lebsoftRoundToTwo(value / 1000).toString() + "kB";
                }
                else
                {
                    return lebsoftRoundToTwo(value / 1000000).toString() + "MB";
                }
            }
            else
            {
                return value;
            }
        };
    });