<%@ Control Language="C#" AutoEventWireup="true" Inherits="modules_home_coda_slider" Codebehind="coda_slider.ascx.cs" %>
<script type="text/javascript" src="/Scripts/jquery.easing.1.3.js"></script>
<script type="text/javascript" src="/Scripts/jquery.coda-slider-2.0.js"></script>
<div class="coda-slider-wrapper">
    <div class="coda-slider preload" id="codaSlider1">
        <asp:Repeater ID="XRepeater" runat="server">
            <ItemTemplate>
                <div class="panelCoda">
                    <div class="panel-wrapper">
                        <div style="height: <%=this.BannerHeight %>px;">
                            <h2 class="title">
                            </h2>
                            <p>
                                <asp:Literal ID="PanelContentLiteral" runat="server" Text='<%#Eval("RealContent") %>'>
                                </asp:Literal>
                            </p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

<script type="text/javascript" language="javascript">
<!--
    $(document).ready(function() {

    $("#codaSlider1").codaSlider({
            dynamicArrows:true,
            autoSlide: <%=this.AutoSlide.ToString().ToLower() %>,
            autoSlideInterval: <%=this.AutoSlideInterval.ToString() %>,
            autoSlideStopWhenClicked: <%=this.AutoSlideStopWhenClicked.ToString().ToLower()  %>,
            dynamicTabsPosition: 'bottom',
            dynamicArrowLeftText: "<img alt='' src='<%=this.LeftImage %>' /> ",
            dynamicArrowRightText: "<img alt='' src='<%=this.RightImage %>' /> ",
            dynamicTabsAlign:"right"
        });

    });
-->
</script>

