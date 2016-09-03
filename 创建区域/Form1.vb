Public Class Form1
    Private Declare Function CreateEllipticRgn Lib "gdi32" Alias "CreateEllipticRgn" (ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer) As Integer '由两个点创建椭圆
    Private Declare Function CreateEllipticRgnIndirect Lib "gdi32" Alias "CreateEllipticRgnIndirect" (lpRect As Rectangle) As Integer '由区域创建椭圆
    Private Declare Function CreatePolygonRgn Lib "gdi32" (lpPoint As Point, ByVal nCount As Integer, ByVal nPolyFillMode As Integer) As Integer '多边形
    Private Declare Function CreatePolyPolygonRgn Lib "gdi32" Alias "CreatePolyPolygonRgn" (lpPoint As Point, lpPolyCounts As Integer, ByVal nCount As Integer, ByVal nPolyFillMode As Integer) As Integer '创建由多个多边形构成的区域
    Private Declare Function CreateRectRgn Lib "gdi32" Alias "CreateRectRgn" (ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer) As Integer '矩形
    Private Declare Function CreateRectRgnIndirect Lib "gdi32" Alias "CreateRectRgnIndirect" (lpRect As Rectangle) As Integer 'Rectangle转为矩形
    Private Declare Function CreateRoundRectRgn Lib "gdi32" Alias "CreateRoundRectRgn" (ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer, ByVal X3 As Integer, ByVal Y3 As Integer) As Integer '圆角矩形
    Private Declare Function OffsetRgn Lib "gdi32" Alias "OffsetRgn" (ByVal hRgn As Integer, ByVal x As Integer, ByVal y As Integer) As Integer '平移区域
    Private Declare Function CombineRgn Lib "gdi32" Alias "CombineRgn" (ByVal hDestRgn As Integer, ByVal hSrcRgn1 As Integer, ByVal hSrcRgn2 As Integer, ByVal nCombineMode As Integer) As Integer '组合两个区域
    Private Const RGN_AND = 1 '交集
    Private Const RGN_OR = 2 '并集
    Private Const RGN_XOR = 3 '并集减交集
    Private Const RGN_DIFF = 4 'hRgn1减交集

    Private Declare Function SetWindowRgn Lib "user32" Alias "SetWindowRgn" (ByVal hWnd As Integer, ByVal hRgn As Integer, ByVal bRedraw As Boolean) As Integer '更改窗口区域
    Private Declare Function DeleteObject Lib "gdi32" Alias "DeleteObject" (ByVal hObject As Integer) As Integer '释放对象资源

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MyRegion As Integer, TempRange As Integer
        MyRegion = CreateEllipticRgn(0, 0, Me.Width, Me.Height)
        TempRange = CreateRoundRectRgn(Me.Width / 2, Me.Height / 2, Me.Width, Me.Height, 20, 30)
        CombineRgn(MyRegion, MyRegion, TempRange, 4)
        SetWindowRgn(Me.Handle, MyRegion, 1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
