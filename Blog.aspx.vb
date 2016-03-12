Public Class WebForm1
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblCurrpage As System.Web.UI.WebControls.Label
    Protected WithEvents lnkPrev As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkNext As System.Web.UI.WebControls.HyperLink
    Protected WithEvents dlstBlog As System.Web.UI.WebControls.DataList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Test if the page is loaded for the first time
        If Not Page.IsPostBack Then
            Dim DstBlog As New DataSet
            DstBlog.ReadXml(Server.MapPath("blog.xml"))

            Dim DvwBlog As DataView
            DvwBlog = New DataView(DstBlog.Tables(0))
            DvwBlog.Sort = "DATE desc"
            DvwBlog.RowFilter = "DISPLAYFLAG = 'Y'"

            Dim PageDSBlog As New PagedDataSource
            PageDSBlog.DataSource = DvwBlog
            PageDSBlog.AllowPaging = True
            PageDSBlog.PageSize = 4
            Dim intCurrentPage As Integer

            If Not IsNothing(Request.QueryString("Page")) Then
                intCurrentPage = Convert.ToInt32(Request.QueryString("Page"))
            Else
                intCurrentPage = 1
            End If

            PageDSBlog.CurrentPageIndex = intCurrentPage - 1
            lblCurrpage.Text = "Page: " + intCurrentPage.ToString()

            If Not PageDSBlog.IsFirstPage Then
                lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath & "?Page=" & CStr(intCurrentPage - 1)
                lnkPrev.Font.Underline = True
            End If

            If Not PageDSBlog.IsLastPage Then
                lnkNext.NavigateUrl = Request.CurrentExecutionFilePath & "?Page=" & CStr(intCurrentPage + 1)
                lnkNext.Font.Underline = True
            End If

            dlstBlog.DataSource = PageDSBlog
            dlstBlog.DataBind()
        End If
    End Sub

    

End Class