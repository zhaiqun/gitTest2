<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="zhaiqunHeimaTest.UI.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="jQuery1.8.3/jquery-1.8.3.js"></script>
    <script  type="text/javascript">
        $(function () {
            $('#btnEdit').click(function () {
                var postData = $('#formEdit').serializeArray();
                $.post("Update.ashx", postData, function (result) {
                    if (result == "ok") {
                        alert('数据修改成功');
                        $('#divEdit').hide();
                    }
                    else {
                        alert('数据修改失败');
                    }
                });
            });
        });
        function updateData(e) {
              <%--  //PersonID, Name, Gender, Age, Email--%>
            $('#divEdit').show();
            var id = parseInt(e.id);
            $.getJSON('SelectModelById.ashx?random=' + Math.random(), { personId: id }, function (_jsonData) {
                $('#txtName').val(_jsonData.Name);
                $('#txtAge').val(_jsonData.Age);
                $('#gender').val(_jsonData.Gender)
                $('#txtEmail').val(_jsonData.Email);
                $('#hidId').val(_jsonData.PersonID)
            });
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                             <th>姓名</th>
                            <th>性别</th>
                            <th>年龄</th>
                            <th>邮箱</th>
                            <th colspan="2">操作</th>
                        </tr>
                       
                    </thead>
            <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                     <%--  //PersonID, Name, Gender, Age, Email--%>
                <tr>
                    <td><%#Eval("PersonID") %></td>
                     <td><%#Eval("Name") %></td>
                     <td><%#Eval("Gender") %></td>
                     <td><%#Eval("Age") %></td>
                    <td><%#Eval("Email") %></td>
                    <td><a  href="ProcessDelete.ashx?personId=<%#Eval("PersonID") %>" onclick="return confirm('确定要删除么')">删除</a></td>
                    <td> <td><a  onclick="updateData(this)" id='<%#Eval("PersonID") %>' href="#">编辑</a></td></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
        <span ><%=this.nav%> </span>
    </form>
      <div id="divEdit"  style="display:none">
        <form id="formEdit">
            <table>
                <tr>
                    <td>姓名</td>
                    <td>
                        <input type="text" name="txtName" value=""  id="txtName"/>
                    </td>
                </tr>
                <tr>
                    <td>性别</td>
                    <td>
                        <select name="gender"  id="gender">
                            <option value="男">男</option>
                             <option value="女">女</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>年龄</td>
                    <td>
                        <input type="text" name="txtAge" value=""  id="txtAge"/>
                    </td>
                </tr>
                   <tr>
                    <td>邮箱</td>
                    <td>
                        <input type="text" name="txtEmail" value=""  id="txtEmail"/>
                    </td>
                </tr>
            </table>
            <input type="button" name="btnEdit" value=" 修改"  id="btnEdit"/>
            <input type="hidden" name="hidId" value=" "  id="hidId"/>
        </form>
    </div>

</body>
</html>
