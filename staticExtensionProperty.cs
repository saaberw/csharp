 public static class IFrmDetailFunctions
    {
        private static DateTime modifiedTime{ get; set; }
        public static DateTime getModifiedTime(this IDetailViewForm frm)
        {
            return modifiedTime;
        }        
        public static void setModifiedTime(this IDetailViewForm frm,DateTime time)
        {
            modifiedTime=time; 
        }

    }
   
    public interface IListViewForm
    {
        Type getDetailFormType { get; set; }
        DateTime listModifiedTime { get; set; }
        DateTime listRefreshedTime { get; set; }

        void refreshList();
    }

    public interface IDetailViewForm
    {

    }

//...
    
//-----------------------[ set value for static (singleton) prop ]------------------------------------
if (frm is IDetailViewForm)
if(frm.parentFrmList != null)
     (this as IDetailViewForm).setModifiedTime( DateTime.Now);


//-----------------------[ get value from static prop ]------------------------------------
if (frm is IListViewForm)
{
    IListViewForm parentForm = frm as IListViewForm;
    Type childForm =(frm as IListViewForm).getDetailFormType;
    if (childForm is IDetailViewForm)
    {
        DateTime modifiedTime=(childForm as IDetailViewForm).getModifiedTime();
        if (parentForm.listRefreshedTime < modifiedTime)
            parentForm.refreshList();
    }
}


