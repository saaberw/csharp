public static class IFrmDetailFunctions
    {
        private static DateTime modifiedTimeVal { get; set; }
        public static DateTime getModifiedTime(this IFrmDetail frm)
        {
            return modifiedTimeVal;
        }        
        public static void setModifiedTime(this IFrmDetail frm,DateTime modifiedTime)
        {
            modifiedTimeVal=modifiedTime;
        }

    }
