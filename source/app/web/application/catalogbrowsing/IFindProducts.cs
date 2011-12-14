namespace app.specs
{
    using app.web.application.catalogbrowsing;

    public interface IFindProducts
    {
        void get_all_products_in_department(DepartmentItem departmentItem);
    }
}