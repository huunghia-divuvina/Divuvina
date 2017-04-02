using System.Web;
using System.Web.Optimization;

namespace Divuvina
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            //---------------------------------------------------
            #region Bootstrap
            //---------------------------
            #region BEGIN GLOBAL MANDATORY STYLES
            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.css",
                      "~/Content/style.css"));
            
            // Font Awesome icons
            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                      "~/fonts/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));

            // jQueryUI CSS
            bundles.Add(new ScriptBundle("~/Scripts/plugins/jquery-ui/jqueryuiStyles").Include(
                        "~/Scripts/plugins/jquery-ui/jquery-ui.css"));

            #endregion END GLOBAL MANDATORY STYLES

            //---------------------------
            #region BEGIN THEME GLOBAL STYLES
            // Morriss chart css styles
            bundles.Add(new StyleBundle("~/plugins/morrisStyles").Include(
                      "~/Content/plugins/morris/morris-0.4.3.min.css"));
            #endregion END THEME GLOBAL STYLES

            //---------------------------
            #region BEGIN THEME LAYOUT STYLES
            // Lightbox gallery css styles
            bundles.Add(new StyleBundle("~/Content/plugins/blueimp/css/").Include(
                      "~/Content/plugins/blueimp/css/blueimp-gallery.min.css"));
            // Awesome bootstrap checkbox
            bundles.Add(new StyleBundle("~/plugins/awesomeCheckboxStyles").Include(
                      "~/Content/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"));

            #endregion END THEME LAYOUT STYLES

            //---------------------------SCRIPTS
            #region BEGIN CORE PLUGINS SCRIPTS
            // SlimScroll
            bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include(
                      "~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js"));

            // Peity
            bundles.Add(new ScriptBundle("~/plugins/peity").Include(
                      "~/Scripts/plugins/peity/jquery.peity.min.js"));

            // Video responsible
            bundles.Add(new ScriptBundle("~/plugins/videoResponsible").Include(
                      "~/Scripts/plugins/video/responsible-video.js"));

            #endregion END CORE PLUGINS SCRIPTS

            //---------------------------SCRIPTS
            #region BEGIN GLOBAL MANDATORY SCRIPTS
            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.1.min.js"));
            // jQueryUI 
            bundles.Add(new StyleBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/plugins/jquery-ui/jquery-ui.min.js"));
            // validate 
            bundles.Add(new ScriptBundle("~/plugins/validate").Include(
                      "~/Scripts/plugins/validate/jquery.validate.min.js"));

            #endregion END GLOBAL MANDATORY SCRIPTS

            //---------------------------SCRIPTS
            #region BEGIN THEME GLOBAL SCRIPTS
            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));
            // Inspinia script
            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include(
                      "~/Scripts/plugins/metisMenu/metisMenu.min.js",
                      "~/Scripts/plugins/pace/pace.min.js",
                      "~/Scripts/app/inspinia.js"));
            // Inspinia skin config script
            bundles.Add(new ScriptBundle("~/bundles/skinConfig").Include(
                      "~/Scripts/app/skin.config.min.js"));
            // Morriss chart
            bundles.Add(new ScriptBundle("~/plugins/morris").Include(
                      "~/Scripts/plugins/morris/raphael-2.1.0.min.js",
                      "~/Scripts/plugins/morris/morris.js"));

            #endregion END THEME GLOBAL SCRIPTS

            //---------------------------SCRIPTS
            #region BEGIN THEME LAYOUT SCRIPTS
            #endregion END THEME LAYOUT SCRIPTS

            //---------------------------STYLES & SCRIPTS
            #region BEGIN PAGE LEVEL 

            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Markdown Styless
            bundles.Add(new StyleBundle("~/plugins/markdownStyles").Include(
            "~/Content/plugins/bootstrap-markdown/bootstrap-markdown.min.css"));

            // Markdown Spin
            bundles.Add(new ScriptBundle("~/plugins/markdown").Include(
                      "~/Scripts/plugins/bootstrap-markdown/bootstrap-markdown.js",
                      "~/Scripts/plugins/bootstrap-markdown/markdown.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // SmartWizard-master  Styless
            bundles.Add(new StyleBundle("~/Content/plugins/SmartWizard-master").Include(
                      "~/Content/plugins/SmartWizard-master/smart_wizard.css",
                      "~/Content/plugins/SmartWizard-master/smart_wizard.min.css",
                      "~/Content/plugins/SmartWizard-master/smart_wizard_theme_arrows.css",
                      "~/Content/plugins/SmartWizard-master/smart_wizard_theme_arrows.min.css",
                      "~/Content/plugins/SmartWizard-master/smart_wizard_theme_circles.css",
                      "~/Content/plugins/SmartWizard-master/smart_wizard_theme_circles.min.css",
                      "~/Content/plugins/SmartWizard-master/smart_wizard_theme_dots.css",
                      "~/Content/plugins/SmartWizard-master/smart_wizard_theme_dots.min.css"));
            // SmartWizard-master Spin
            bundles.Add(new ScriptBundle("~/plugins/SmartWizard-master").Include(
                      "~/Scripts/plugins/SmartWizard-master/jquery.smartWizard.js",
                      "~/Scripts/plugins/SmartWizard-master/jquery.smartWizard.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // c3 Styless
            bundles.Add(new StyleBundle("~/plugins/c3Styles").Include(
                      "~/Content/plugins/c3/c3.min.css"));

            // c3 Spin
            bundles.Add(new ScriptBundle("~/plugins/c3").Include(
                      "~/Scripts/plugins/c3/c3.min.js"));

            // d3 Spin
            bundles.Add(new ScriptBundle("~/plugins/d3").Include(
                      "~/Scripts/plugins/d3/d3.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // iCheck css styles
            bundles.Add(new StyleBundle("~/Content/plugins/iCheck/iCheckStyles").Include(
                      "~/Content/plugins/iCheck/custom.css"));

            // iCheck
            bundles.Add(new ScriptBundle("~/plugins/iCheck").Include(
                      "~/Scripts/plugins/iCheck/icheck.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // dataTables css styles
            bundles.Add(new StyleBundle("~/Content/plugins/dataTables/dataTablesStyles").Include(
                      "~/Content/plugins/dataTables/datatables.min.css"));

            // dataTables 
            bundles.Add(new ScriptBundle("~/plugins/dataTables").Include(
                      "~/Scripts/plugins/dataTables/datatables.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // jeditable 
            bundles.Add(new ScriptBundle("~/plugins/jeditable").Include(
                      "~/Scripts/plugins/jeditable/jquery.jeditable.js"));

            // jqGrid styles
            bundles.Add(new StyleBundle("~/Content/plugins/jqGrid/jqGridStyles").Include(
                      "~/Content/plugins/jqGrid/ui.jqgrid.css"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // codeEditor styles
            bundles.Add(new StyleBundle("~/plugins/codeEditorStyles").Include(
                      "~/Content/plugins/codemirror/codemirror.css",
                      "~/Content/plugins/codemirror/ambiance.css"));

            // codeEditor 
            bundles.Add(new ScriptBundle("~/plugins/codeEditor").Include(
                      "~/Scripts/plugins/codemirror/codemirror.js",
                      "~/Scripts/plugins/codemirror/mode/javascript/javascript.js"));
            // codeEditor 
            bundles.Add(new ScriptBundle("~/plugins/nestable").Include(
                      "~/Scripts/plugins/nestable/jquery.nestable.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // fullCalendar styles
            bundles.Add(new StyleBundle("~/plugins/fullCalendarStyles").Include(
                      "~/Content/plugins/fullcalendar/fullcalendar.css"));

            // fullCalendar 
            bundles.Add(new ScriptBundle("~/plugins/fullCalendar").Include(
                      "~/Scripts/plugins/fullcalendar/moment.min.js",
                      "~/Scripts/plugins/fullcalendar/fullcalendar.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // datePicker styles
            bundles.Add(new StyleBundle("~/plugins/datePickerStyles").Include(
                      "~/Content/plugins/datepicker/datepicker3.css"));

            // datePicker 
            bundles.Add(new ScriptBundle("~/plugins/datePicker").Include(
                      "~/Scripts/plugins/datepicker/bootstrap-datepicker.js",
                      "~/Scripts/plugins/datepicker/bootstrap-datepicker.en.js"
                      ));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // ionRange styles
            bundles.Add(new StyleBundle("~/Content/plugins/ionRangeSlider/ionRangeStyles").Include(
                      "~/Content/plugins/ionRangeSlider/ion.rangeSlider.css",
                      "~/Content/plugins/ionRangeSlider/ion.rangeSlider.skinFlat.css"));

            // ionRange 
            bundles.Add(new ScriptBundle("~/plugins/ionRange").Include(
                      "~/Scripts/plugins/ionRangeSlider/ion.rangeSlider.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // nouiSlider styles
            bundles.Add(new StyleBundle("~/plugins/nouiSliderStyles").Include(
                      "~/Content/plugins/nouslider/jquery.nouislider.css"));

            // nouiSlider 
            bundles.Add(new ScriptBundle("~/plugins/nouiSlider").Include(
                      "~/Scripts/plugins/nouslider/jquery.nouislider.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // jasnyBootstrap styles
            bundles.Add(new StyleBundle("~/plugins/jasnyBootstrapStyles").Include(
                      "~/Content/plugins/jasny/jasny-bootstrap.min.css"));

            // jasnyBootstrap 
            bundles.Add(new ScriptBundle("~/plugins/jasnyBootstrap").Include(
                      "~/Scripts/plugins/jasny/jasny-bootstrap.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // switchery styles
            bundles.Add(new StyleBundle("~/plugins/switcheryStyles").Include(
                      "~/Content/plugins/switchery/switchery.css"));

            // switchery 
            bundles.Add(new ScriptBundle("~/plugins/switchery").Include(
                      "~/Scripts/plugins/switchery/switchery.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // chosen styles
            bundles.Add(new StyleBundle("~/Content/plugins/chosen/chosenStyles").Include(
                      "~/Content/plugins/chosen/chosen.css"));

            // chosen 
            bundles.Add(new ScriptBundle("~/plugins/chosen").Include(
                      "~/Scripts/plugins/chosen/chosen.jquery.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // wizardSteps styles
            bundles.Add(new StyleBundle("~/plugins/wizardStepsStyles").Include(
                      "~/Content/plugins/steps/jquery.steps.css"));

            // wizardSteps 
            bundles.Add(new ScriptBundle("~/plugins/wizardSteps").Include(
                      "~/Scripts/plugins/staps/jquery.steps.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // dropZone styles
            bundles.Add(new StyleBundle("~/Content/plugins/dropzone/dropZoneStyles").Include(
                      "~/Content/plugins/dropzone/basic.css",
                      "~/Content/plugins/dropzone/dropzone.css"));

            // dropZone 
            bundles.Add(new ScriptBundle("~/plugins/dropZone").Include(
                      "~/Scripts/plugins/dropzone/dropzone.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // summernote styles
            bundles.Add(new StyleBundle("~/plugins/summernoteStyles").Include(
                      "~/Content/plugins/summernote/summernote.css",
                      "~/Content/plugins/summernote/summernote-bs3.css"));

            // summernote 
            bundles.Add(new ScriptBundle("~/plugins/summernote").Include(
                      "~/Scripts/plugins/summernote/summernote.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // toastr notification 
            bundles.Add(new ScriptBundle("~/plugins/toastr").Include(
                      "~/Scripts/plugins/toastr/toastr.min.js"));

            // toastr notification styles
            bundles.Add(new StyleBundle("~/plugins/toastrStyles").Include(
                      "~/Content/plugins/toastr/toastr.min.css"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // color picker
            bundles.Add(new ScriptBundle("~/plugins/colorpicker").Include(
                      "~/Scripts/plugins/colorpicker/bootstrap-colorpicker.min.js"));

            // color picker styles
            bundles.Add(new StyleBundle("~/Content/plugins/colorpicker/colorpickerStyles").Include(
                      "~/Content/plugins/colorpicker/bootstrap-colorpicker.min.css"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // image cropper
            bundles.Add(new ScriptBundle("~/plugins/imagecropper").Include(
                      "~/Scripts/plugins/cropper/cropper.min.js"));

            // image cropper styles
            bundles.Add(new StyleBundle("~/plugins/imagecropperStyles").Include(
                      "~/Content/plugins/cropper/cropper.min.css"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // jsTree
            bundles.Add(new ScriptBundle("~/plugins/jsTree").Include(
                      "~/Scripts/plugins/jsTree/jstree.min.js"));

            // jsTree styles
            bundles.Add(new StyleBundle("~/Content/plugins/jsTree").Include(
                      "~/Content/plugins/jsTree/style.css"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Clockpicker styles
            bundles.Add(new StyleBundle("~/plugins/clockpickerStyles").Include(
                      "~/Content/plugins/clockpicker/clockpicker.css"));

            // Clockpicker
            bundles.Add(new ScriptBundle("~/plugins/clockpicker").Include(
                      "~/Scripts/plugins/clockpicker/clockpicker.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Date range picker Styless
            bundles.Add(new StyleBundle("~/plugins/dateRangeStyles").Include(
                      "~/Content/plugins/daterangepicker/daterangepicker-bs3.css"));

            // Date range picker
            bundles.Add(new ScriptBundle("~/plugins/dateRange").Include(
                      // Date range use moment.js same as full calendar plugin 
                      "~/Scripts/plugins/fullcalendar/moment.min.js",
                      "~/Scripts/plugins/daterangepicker/daterangepicker.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Sweet alert Styless
            bundles.Add(new StyleBundle("~/plugins/sweetAlertStyles").Include(
                      "~/Content/plugins/sweetalert/sweetalert.css"));

            // Sweet alert
            bundles.Add(new ScriptBundle("~/plugins/sweetAlert").Include(
                      "~/Scripts/plugins/sweetalert/sweetalert.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Footable Styless
            bundles.Add(new StyleBundle("~/plugins/footableStyles").Include(
                      "~/Content/plugins/footable/footable.core.css", new CssRewriteUrlTransform()));

            // Footable alert
            bundles.Add(new ScriptBundle("~/plugins/footable").Include(
                      "~/Scripts/plugins/footable/footable.all.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Select2 Styless
            bundles.Add(new StyleBundle("~/plugins/select2Styles").Include(
                      "~/Content/plugins/select2/select2.min.css"));

            // Select2
            bundles.Add(new ScriptBundle("~/plugins/select2").Include(
                      "~/Scripts/plugins/select2/select2.full.min.js"));

            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Slick carousel Styless
            bundles.Add(new StyleBundle("~/plugins/slickStyles").Include(
                      "~/Content/plugins/slick/slick.css", new CssRewriteUrlTransform()));

            // Slick carousel theme Styless
            bundles.Add(new StyleBundle("~/plugins/slickThemeStyles").Include(
                      "~/Content/plugins/slick/slick-theme.css", new CssRewriteUrlTransform()));

            // Slick carousel
            bundles.Add(new ScriptBundle("~/plugins/slick").Include(
                      "~/Scripts/plugins/slick/slick.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Ladda buttons Styless
            bundles.Add(new StyleBundle("~/plugins/laddaStyles").Include(
                      "~/Content/plugins/ladda/ladda-themeless.min.css"));

            // Ladda buttons
            bundles.Add(new ScriptBundle("~/plugins/ladda").Include(
                      "~/Scripts/plugins/ladda/spin.min.js",
                      "~/Scripts/plugins/ladda/ladda.min.js",
                      "~/Scripts/plugins/ladda/ladda.jquery.min.js"));

            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Touch Spin Styless
            bundles.Add(new StyleBundle("~/plugins/touchSpinStyles").Include(
                      "~/Content/plugins/touchspin/jquery.bootstrap-touchspin.min.css"));

            // Touch Spin
            bundles.Add(new ScriptBundle("~/plugins/touchSpin").Include(
                      "~/Scripts/plugins/touchspin/jquery.bootstrap-touchspin.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Tour Styless
            bundles.Add(new StyleBundle("~/plugins/tourStyles").Include(
                      "~/Content/plugins/bootstrapTour/bootstrap-tour.min.css"));

            // Tour Spin
            bundles.Add(new ScriptBundle("~/plugins/tour").Include(
                      "~/Scripts/plugins/bootstrapTour/bootstrap-tour.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Chartist
            bundles.Add(new StyleBundle("~/plugins/chartistStyles").Include(
                      "~/Content/plugins/chartist/chartist.min.css"));

            // jsTree styles
            bundles.Add(new ScriptBundle("~/plugins/chartist").Include(
                      "~/Scripts/plugins/chartist/chartist.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            #endregion END PAGE LEVEL SCRIPTS

            //---------------------------SCRIPTS
            #region BEGIN COMPONENTS SCRIPTS
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Lightbox gallery
            bundles.Add(new ScriptBundle("~/plugins/lightboxGallery").Include(
                      "~/Scripts/plugins/blueimp/jquery.blueimp-gallery.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Sparkline
            bundles.Add(new ScriptBundle("~/plugins/sparkline").Include(
                      "~/Scripts/plugins/sparkline/jquery.sparkline.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Flot chart
            bundles.Add(new ScriptBundle("~/plugins/flot").Include(
                      "~/Scripts/plugins/flot/jquery.flot.js",
                      "~/Scripts/plugins/flot/jquery.flot.tooltip.min.js",
                      "~/Scripts/plugins/flot/jquery.flot.resize.js",
                      "~/Scripts/plugins/flot/jquery.flot.pie.js",
                      "~/Scripts/plugins/flot/jquery.flot.time.js",
                      "~/Scripts/plugins/flot/jquery.flot.spline.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Rickshaw chart
            bundles.Add(new ScriptBundle("~/plugins/rickshaw").Include(
                      "~/Scripts/plugins/rickshaw/vendor/d3.v3.js",
                      "~/Scripts/plugins/rickshaw/rickshaw.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // ChartJS chart
            bundles.Add(new ScriptBundle("~/plugins/chartJs").Include(
                      "~/Scripts/plugins/chartjs/Chart.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // jqGrid 
            bundles.Add(new ScriptBundle("~/plugins/jqGrid").Include(
                      "~/Scripts/plugins/jqGrid/i18n/grid.locale-en.js",
                      "~/Scripts/plugins/jqGrid/jquery.jqGrid.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // vectorMap 
            bundles.Add(new ScriptBundle("~/plugins/vectorMap").Include(
                      "~/Scripts/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                      "~/Scripts/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // knob 
            bundles.Add(new ScriptBundle("~/plugins/knob").Include(
                      "~/Scripts/plugins/jsKnob/jquery.knob.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Diff
            bundles.Add(new ScriptBundle("~/plugins/diff").Include(
                      "~/Scripts/plugins/diff_match_patch/javascript/diff_match_patch.js",
                      "~/Scripts/plugins/preetyTextDiff/jquery.pretty-text-diff.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Idle timer
            bundles.Add(new ScriptBundle("~/plugins/idletimer").Include(
                      "~/Scripts/plugins/idle-timer/idle-timer.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Tinycon
            bundles.Add(new ScriptBundle("~/plugins/tinycon").Include(
                      "~/Scripts/plugins/tinycon/tinycon.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Masonry
            bundles.Add(new ScriptBundle("~/plugins/masonry").Include(
                      "~/Scripts/plugins/masonary/masonry.pkgd.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Dotdotdot buttons
            bundles.Add(new ScriptBundle("~/plugins/truncate").Include(
                      "~/Scripts/plugins/dotdotdot/jquery.dotdotdot.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // i18next Spin
            bundles.Add(new ScriptBundle("~/plugins/i18next").Include(
                      "~/Scripts/plugins/i18next/i18next.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            // Clipboard Spin
            bundles.Add(new ScriptBundle("~/plugins/clipboard").Include(
                      "~/Scripts/plugins/clipboard/clipboard.min.js"));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            #endregion BEGIN COMPONENTS SCRIPTS

            #endregion Bootstrap

            //---------------------------------------------------
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
            #region Metronic

            //---------------------------
            #region BEGIN GLOBAL MANDATORY STYLES
            //Using Bootstrap
            //bundles.Add(new StyleBundle("~/Metronic/global/plugins/font-awesome/css").Include(
            //          "~/Metronic/global/plugins/font-awesome/css/font-awesome.min.css"));
            bundles.Add(new StyleBundle("~/Metronic/global/plugins/simple-line-icons").Include(
                      "~/Metronic/global/plugins/simple-line-icons/simple-line-icons.min.css"));
            //Using Bootstrap
            //bundles.Add(new StyleBundle("~/Metronic/global/plugins/bootstrap/css").Include(
            //                      "~/Metronic/global/plugins/bootstrap/css/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Metronic/global/plugins/bootstrap-switch/css").Include(
                                  "~/Metronic/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"));

            #endregion END GLOBAL MANDATORY STYLES

            //---------------------------
            #region BEGIN THEME GLOBAL STYLES
            bundles.Add(new StyleBundle("~/Metronic/global/css").Include(
                      "~/Metronic/global/css/components.min.css",
                      "~/Metronic/global/css/plugins.min.css"));
            #endregion END THEME GLOBAL STYLES

            //---------------------------
            #region BEGIN THEME LAYOUT STYLES
            bundles.Add(new StyleBundle("~/Metronic/layouts/layout/css").Include(
                    "~/Metronic/layouts/layout/css/layout.min.css",
                    "~/Metronic/layouts/layout/css/themes/darkblue.min.css",
                    "~/Metronic/layouts/layout/css/custom.min.css"));
            #endregion END THEME LAYOUT STYLES

            //---------------------------SCRIPTS
            #region BEGIN CORE PLUGINS
            bundles.Add(new ScriptBundle("~/Metronic/global/plugins").Include(
                //"~/Metronic/global/plugins/jquery.min.js",
                //"~/Metronic/global/plugins/bootstrap/js/bootstrap.min.js",
                "~/Metronic/global/plugins/js.cookie.min.js",
                "~/Metronic/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                "~/Metronic/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Metronic/global/plugins/jquery.blockui.min.js",
                "~/Metronic/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"
                ));

            #endregion END CORE PLUGINS

            //---------------------------SCRIPTS
            #region BEGIN THEME GLOBAL SCRIPTS
            bundles.Add(new ScriptBundle("~/Metronic/global/scripts").Include(
                "~/Metronic/global/scripts/app.min.js"
                ));
            #endregion END THEME GLOBAL SCRIPTS

            //---------------------------SCRIPTS
            #region BEGIN PAGE LEVEL SCRIPTS
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            bundles.Add(new ScriptBundle("~/Metronic/pages/scripts").Include(
                "~/Metronic/pages/scripts/dashboard.min.js"
                ));
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-----------------------------------
            
            #endregion END PAGE LEVEL SCRIPTS

            //---------------------------SCRIPTS
            #region BEGIN THEME LAYOUT SCRIPTS
            bundles.Add(new ScriptBundle("~/Metronic/layouts/layout/scripts").Include(
                "~/Metronic/layouts/layout/scripts/layout.min.js",
                "~/Metronic/layouts/layout/scripts/demo.min.js",
                "~/Metronic/layouts/layout/scripts/quick-sidebar.min.js"
                ));
            #endregion END THEME LAYOUT SCRIPTS

            #endregion Metronic

            //---------------------------------------------------
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
            #region Divuvina.

            // nghuuphuoc
            bundles.Add(new StyleBundle("~/nghuuphuoc-bootstrapvalidator-v0.5.2").Include(
                      "~/Content/plugins/nghuuphuoc-bootstrapvalidator-v0.5.2/bootstrapValidator.css"));

            bundles.Add(new ScriptBundle("~/plugins/nghuuphuoc-bootstrapvalidator-v0.5.2").Include(
                //"~/Scripts/plugins/nghuuphuoc-bootstrapvalidator-v0.5.2/language/vi_VN.js",
                //"~/Scripts/plugins/nghuuphuoc-bootstrapvalidator-v0.5.2/validator/base64.js",
                //"~/Scripts/plugins/nghuuphuoc-bootstrapvalidator-v0.5.2/validator/between.js",
                //"~/Scripts/plugins/nghuuphuoc-bootstrapvalidator-v0.5.2/validator/.js",
                "~/Scripts/plugins/nghuuphuoc-bootstrapvalidator-v0.5.2/bootstrapValidator.js"
                ));


            bundles.Add(new StyleBundle("~/Divuvina").Include(
                      "~/Content/Divuvina/divuvina.css"));

            bundles.Add(new ScriptBundle("~/Public/HamDungChung").Include(
                "~/Scripts/Public/ClientGlobalVars.js",
                "~/Scripts/Public/ConvertingFunctions.js",
                "~/Scripts/Public/ValidationFunctions.js",
                "~/Scripts/Public/ShowMessage.js",
                "~/Scripts/Public/SettingControls.js"
                ));

            #endregion

            //---------------------------------------------------
            //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
            
        }
    }
}
