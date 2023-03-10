using BlueLotus360.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class ItemSimple : BaseEntity
    {
        public string ItemName { get; set; } = ""; // Added
        public long ItemKey { get; set; } // Added
        public string ItemCode { get; set; } = "";  // Added
        public string ItemNameOnly { get; set; } = "";   // Added

        public string ItemCodeOnly { get; set; } = "";  // Added


        public int FilterKey { get; set; }
        public ItemSimple()
        {
            ItemKey = 1;
        }
        public ItemSimple(int ItemKey)
        {
            this.ItemKey = ItemKey;
        }

        public bool IsParentItem { get; set; }

        public string? ComboTitle
        {
            get
            {
                if (ItemKey == 1)
                {
                    return "-";
                }
                else
                {
                    return ItemName;
                }
            }
        }


        public CodeBaseResponse ItemType { get; set; }= new CodeBaseResponse();

        //public string? Base64ImageDocument { get; set; } = "data:image/jpeg;base64,/9j/4QUmRXhpZgAASUkqAAgAAAAOAAABAwABAAAAZAIAAAEBAwABAAAAZAIAAAIBAwADAAAAtgAAAAYBAwABAAAAAgAAAA4BAgBpAA" +
        // "AAvAAAABIBAwABAAAAAQAAABUBAwABAAAAAwAAABoBBQABAAAAJQEAABsBBQABAAAALQEAACgBAwABAAAAAgAAADEBAgAiAAAANQEAADIBAgAUAAAAVwEAADsBAgAJAAAAawEAAGmHBAABAAAAdAEAAKwBAAAIAAgACABObyBpbWFnZSBhdmF" +
        // "pbGFibGUgc2lnbi4gSW50ZXJuZXQgd2ViIGljb24gdG8gaW5kaWNhdGUgdGhlIGFic2VuY2Ugb2YgaW1hZ2UgdW50aWwgaXQgd2lsbCBiZSBkb3dubG9hZGVkLgDAxi0AECcAAMDGLQAQJwAAQWRvYmUgUGhvdG9zaG9wIENDIDIwMTcgKFdpbmRvd3" +
        // "MpADIwMjI6MDQ6MTggMTM6MDc6MjcAUGUzY2hlY2sABAAAkAcABAAAADAyMjEBoAMAAQAAAP//AAACoAQAAQAAAGQAAAADoAQAAQAAAGQAAAAAAAAAAAAGAAMBAwABAAAABgAAABoBBQABAAAA+gEAABsBBQABAAAAAgIAACgBAwABAAAAAgAAAAECBAABA" +
        // "AAACgIAAAICBAABAAAAFAMAAAAAAABIAAAAAQAAAEgAAAABAAAA/9j/7QAMQWRvYmVfQ00AAv/uAA5BZG9iZQBkgAAAAAH/2wCEAAwICAgJCAwJCQwRCwoLERUPDAwPFRgTExUTExgRDAwMDAwMEQwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwBDQsLDQ4NE" +
        // "A4OEBQODg4UFA4ODg4UEQwMDAwMEREMDAwMDAwRDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDP/AABEIABgAGAMBIgACEQEDEQH/3QAEAAL/xAE/AAABBQEBAQEBAQAAAAAAAAADAAECBAUGBwgJCgsBAAEFAQEBAQEBAAAAAAAAAAEAAgMEBQYHCAkKCxAAAQQ" +
        // "BAwIEAgUHBggFAwwzAQACEQMEIRIxBUFRYRMicYEyBhSRobFCIyQVUsFiMzRygtFDByWSU/Dh8WNzNRaisoMmRJNUZEXCo3Q2F9JV4mXys4TD03Xj80YnlKSFtJXE1OT0pbXF1eX1VmZ2hpamtsbW5vY3R1dnd4eXp7fH1+f3EQACAgECBAQDBAUGBw" +
        // "cGBTUBAAIRAyExEgRBUWFxIhMFMoGRFKGxQiPBUtHwMyRi4XKCkkNTFWNzNPElBhaisoMHJjXC0kSTVKMXZEVVNnRl4vKzhMPTdePzRpSkhbSVxNTk9KW1xdXl9VZmdoaWprbG1ub2JzdHV2d3h5ent8f/2gAMAwEAAhEDEQA/APQ+u9Wd0nDbkNqFpfYK4c7a" +
        // "BIc8uLtr/wDRrG/5wdV9aJpF+71Dgy8vFezf6P8AMtqfeyv9Z9L1/tH+D/4Jan1l6e/qODXjV2V1v9UPAtcWhwDXsc1rmh/u9/7qy/2F1H1zlA437QIn1fXd6e8j0/tX2b7Lu9ba7/T+h636bZ+Ykp2uhdVd1XDdkOYK3MsNZ2mQ6A1wsbP0dzX/AEEkL6t9Nt6bgO" +
        // "otfXY51hf+iJc0AtY1o3ODPzWbvopJKf/Q9NzGb62j0G5J3D2uIEfy5d+6qj6LXGD0+stMDVzTo3TX+sxjNq+aEklP1DgVGqkh1IocT7gHbt0AN9Rzv5SS+XkklP8A/9n/7Q0+UGhvdG9zaG9wIDMuMAA4QklNBAQAAAAAAKYcAVoAAxslRxwCAAACAAAcAngAaE5v" +
        // "IGltYWdlIGF2YWlsYWJsZSBzaWduLiBJbnRlcm5ldCB3ZWIgaWNvbiB0byBpbmRpY2F0ZSB0aGUgYWJzZW5jZSBvZiBpbWFnZSB1bnRpbCBpdCB3aWxsIGJlIGRvd25sb2FkZWQuHAJQAAhQZTNjaGVjaxwCbgAYR2V0dHkgSW1hZ2VzL2lTdG9ja3Bob3RvOEJJTQQ" +
        // "lAAAAAAAQryygMvj00GhVb1q8FCBQ1ThCSU0EOgAAAAAA5QAAABAAAAABAAAAAAALcHJpbnRPdXRwdXQAAAAFAAAAAFBzdFNib29sAQAAAABJbnRlZW51bQAAAABJbnRlAAAAAENscm0AAAAPcHJpbnRTaXh0ZWVuQml0Ym9vbAAAAAALcHJpbnRlc" +
        // "k5hbWVURVhUAAAAAQAAAAAAD3ByaW50UHJvb2ZTZXR1cE9iamMAAAAMAFAAcgBvAG8AZgAgAFMAZQB0AHUAcAAAAAAACnByb29mU2V0dXAAAAABAAAAAEJsdG5lbnVtAAAADGJ1aWx0aW5Qcm9vZgAAAAlwcm9vZkNNWUsAOEJJTQQ7AAAAAAItAAAAEAAAA" +
        // "AEAAAAAABJwcmludE91dHB1dE9wdGlvbnMAAAAXAAAAAENwdG5ib29sAAAAAABDbGJyYm9vbAAAAAAAUmdzTWJvb2wAAAAAAENybkNib29sAAAAAABDbnRDYm9vbAAAAAAATGJsc2Jvb2wAAAAAAE5ndHZib29sAAAAAABFbWxEYm9vbAAAAAAASW50cmJvb2wAAAAA" +
        // "AEJja2dPYmpjAAAAAQAAAAAAAFJHQkMAAAADAAAAAFJkICBkb3ViQG/gAAAAAAAAAAAAR3JuIGRvdWJAb+AAAAAAAAAAAABCbCAgZG91YkBv4AAAAAAAAAAAAEJyZFRVbnRGI1JsdAAAAAAAAAAAAAAAAEJsZCBVbnRGI1JsdAAAAAAAAAAAAAAAAFJzbHRVbnRGI1B4bEByw" +
        // "AAAAAAAAAAACnZlY3RvckRhdGFib29sAQAAAABQZ1BzZW51bQAAAABQZ1BzAAAAAFBnUEMAAAAATGVmdFVudEYjUmx0AAAAAAAAAAAAAAAAVG9wIFVudEYjUmx0AAAAAAAAAAAAAAAAU2NsIFVudEYjUHJjQFkAAAAAAAAAAAAQY3JvcFdoZW5QcmludGluZ2Jvb2wAAAAADmNyb" +
        // "3BSZWN0Qm90dG9tbG9uZwAAAAAAAAAMY3JvcFJlY3RMZWZ0bG9uZwAAAAAAAAANY3JvcFJlY3RSaWdodGxvbmcAAAAAAAAAC2Nyb3BSZWN0VG9wbG9uZwAAAAAAOEJJTQPtAAAAAAAQASwAAAABAAEBLAAAAAEAAThCSU0EJgAAAAAADgAAAAAAAAAAAAA/gAAAOEJJTQQNAAAAAA" +
        // "AEAAAAHjhCSU0EGQAAAAAABAAAAB44QklNA/MAAAAAAAkAAAAAAAAAAAEAOEJJTQQLAAAAAABtaHR0cHM6Ly93d3cuaXN0b2NrcGhvdG8uY29tL2xlZ2FsL2xpY2Vuc2UtYWdyZWVtZW50P3V0bV9tZWRpdW09b3JnYW5pYyZ1dG1fc291cmNlPWdvb2dsZSZ1dG1fY2FtcGFpZ2" +
        // "49aXB0Y3VybAA4QklNJxAAAAAAAAoAAQAAAAAAAAABOEJJTQP1AAAAAABIAC9mZgABAGxmZgAGAAAAAAABAC9mZgABAKGZmgAGAAAAAAABADIAAAABAFoAAAAGAAAAAAABADUAAAABAC0AAAAGAAAAAAAB" +
        // "OEJJTQP4AAAAAABwAAD/////////////////////////////A+gAAAAA/////////////////////////////wPoAAAAAP////////////////////////////8D6AAAAAD/////////////////////////////A+gAADhCSU0E" +
        // "CAAAAAAAEAAAAAEAAAJAAAACQAAAAAA4QklNBB4AAAAAAAQAAAAAOEJJTQQaAAAAAAM/AAAABgAAAAAAAAAAAAAAZAAAAGQAAAAFAE4AbwBpAG4AZwAAAAEAAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAAAAAAAAAAZAAAAGQAAAAAAAAA" +
        // "AAAAAAAAAAAAAQAAAAAAAAAAAAAAAAAAAAAAAAAQAAAAAQAAAAAAAG51bGwAAAACAAAABmJvdW5kc09iamMAAAABAAAAAAAAUmN0MQAAAAQAAAAAVG9wIGxvbmcAAAAAAAAAAExlZnRsb25nAAAAAAAAAABCdG9tbG9uZwAAAGQAAAAAUmdo" +
        // "dGxvbmcAAABkAAAABnNsaWNlc1ZsTHMAAAABT2JqYwAAAAEAAAAAAAVzbGljZQAAABIAAAAHc2xpY2VJRGxvbmcAAAAAAAAAB2dyb3VwSURsb25nAAAAAAAAAAZvcmlnaW5lbnVtAAAADEVTbGljZU9yaWdpbgAAAA1hdXRvR2VuZXJhdGVkAAAAA" +
        // "FR5cGVlbnVtAAAACkVTbGljZVR5cGUAAAAASW1nIAAAAAZib3VuZHNPYmpjAAAAAQAAAAAAAFJjdDEAAAAEAAAAAFRvcCBsb25nAAAAAAAAAABMZWZ0bG9uZwAAAAAAAAAAQnRvbWxvbmcAAABkAAAAAFJnaHRsb25nAAAAZAAAAAN1cmxURVhUAAA" +
        // "AAQAAAAAAAG51bGxURVhUAAAAAQAAAAAAAE1zZ2VURVhUAAAAAQAAAAAABmFsdFRhZ1RFWFQAAAABAAAAAAAOY2VsbFRleHRJc0hUTUxib29sAQAAAAhjZWxsVGV4dFRFWFQAAAABAAAAAAAJaG9yekFsaWduZW51bQAAAA9FU2xpY2VIb3J6QWxpZ24AAAAHZGVmYXVsdAAA" +
        // "AAl2ZXJ0QWxpZ25lbnVtAAAAD0VTbGljZVZlcnRBbGlnbgAAAAdkZWZhdWx0AAAAC2JnQ29sb3JUeXBlZW51bQAAABFFU2xpY2VCR0NvbG9yVHlwZQAAAABOb25lAAAACXRvcE91dHNldGxvbmcAAAAAAAAACmxlZnRPdXRzZXRsb25nAAAAAAAAAAxib3R0b21PdXRzZXRsb25nAA" +
        // "AAAAAAAAtyaWdodE91dHNldGxvbmcAAAAAADhCSU0EKAAAAAAADAAAAAI/8AAAAAAAADhCSU0EEQAAAAAAAQEAOEJJTQQUAAAAAAAEAAAAAjhCSU0EDAAAAAADMAAAAAEAAAAYAAAAGAAAAEgAAAbAAAADFAAYAAH/2P/tAAxBZG9iZV9DTQAC/+4ADkFkb2JlAGSAAAAAAf/bAIQADAgICAkIDAkJDBELCgsRFQ8MDA8VGBMTFRMTGBEMDAwMDAwRDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAENCwsNDg0QDg4QFA4ODhQUDg4ODhQRDAwMDAwREQwMDAwMDBEMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwM/8AAEQgAGAAYAwEiAAIRAQMRAf/dAAQAAv/EAT8AAAEFAQEBAQEBAAAAAAAAAAMAAQIEBQYHCAkKCwEAAQUBAQEBAQEAAAAAAAAAAQACAwQFBgcICQoLEAABBAEDAgQCBQcGCAUDDDMBAAIRAwQhEjEFQVFhEyJxgTIGFJGhsUIjJBVSwWIzNHKC0UMHJZJT8OHxY3M1FqKygyZEk1RkRcKjdDYX0lXiZfKzhMPTdePzRieUpIW0lcTU5PSltcXV5fVWZnaGlqa2xtbm9jdHV2d3h5ent8fX5/cRAAICAQIEBAMEBQYHBwYFNQEAAhEDITESBEFRYXEiEwUygZEUobFCI8FS0fAzJGLhcoKSQ1MVY3M08SUGFqKygwcmNcLSRJNUoxdkRVU2dGXi8rOEw9N14/NGlKSFtJXE1OT0pbXF1eX1VmZ2hpamtsbW5vYnN0dXZ3eHl6e3x//aAAwDAQACEQMRAD8A9D671Z3ScNuQ2oWl9grhztoEhzy4u2v/ANGsb/nB1X1omkX7vUODLy8V7N/o/wAy2p97K/1n0vX+0f4P/glqfWXp7+o4NeNXZXW/1Q8C1xaHANexzWuaH+73/urL/YXUfXOUDjftAifV9d3p7yPT+1fZvsu71trv9P6Hrfptn5iSna6F1V3VcN2Q5grcyw1naZDoDXCxs/R3Nf8AQSQvq3023puA6i19djnWF/6IlzQC1jWjc4M/NZu+ikkp/9D03MZvraPQbkncPa4gR/Ll37qqPotcYPT6y0wNXNOjdNf6zGM2r5oSSU/UOBUaqSHUihxPuAdu3QA31HO/lJL5eSSU/wD/2ThCSU0EIQAAAAAAXQAAAAEBAAAADwBBAGQAbwBiAGUAIABQAGgAbwB0AG8AcwBoAG8AcAAAABcAQQBkAG8AYgBlACAAUABoAG8AdABvAHMAaABvAHAAIABDAEMAIAAyADAAMQA3AAAAAQA4QklNBAYAAAAAAAcACAEBAAEBAP/hEUZodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNi1jMTM4IDc5LjE1OTgyNCwgMjAxNi8wOS8xNC0wMTowOTowMSAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6cGhvdG9zaG9wPSJodHRwOi8vbnMuYWRvYmUuY29tL3Bob3Rvc2hvcC8xLjAvIiB4bWxuczpHZXR0eUltYWdlc0dJRlQ9Imh0dHA6Ly94bXAuZ2V0dHlpbWFnZXMuY29tL2dpZnQvMS4wLyIgeG1sbnM6eG1wUmlnaHRzPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvcmlnaHRzLyIgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIiB4bWxuczpwbHVzPSJodHRwOi8vbnMudXNlcGx1cy5vcmcvbGRmL3htcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiBwaG90b3Nob3A6Q3JlZGl0PSJHZXR0eSBJbWFnZXMvaVN0b2NrcGhvdG8iIHBob3Rvc2hvcDpMZWdhY3lJUFRDRGlnZXN0PSI4QUI3QjI4NTMwNjRGQ0EzODI5OTdCQUY1QTJENjgxRSIgcGhvdG9zaG9wOkNvbG9yTW9kZT0iMyIgcGhvdG9zaG9wOklDQ1Byb2ZpbGU9IiIgR2V0dHlJbWFnZXNHSUZUOkFzc2V0SUQ9IjkyMjk2MjM1NCIgeG1wUmlnaHRzOldlYlN0YXRlbWVudD0iaHR0cHM6Ly93d3cuaXN0b2NrcGhvdG8uY29tL2xlZ2FsL2xpY2Vuc2UtYWdyZWVtZW50P3V0bV9tZWRpdW09b3JnYW5pYyZhbXA7dXRtX3NvdXJjZT1nb29nbGUmYW1wO3V0bV9jYW1wYWlnbj1pcHRjdXJsIiBkYzpmb3JtYXQ9ImltYWdlL2pwZWciIHhtcE1NOkRvY3VtZW50SUQ9IkEzRkM1QkM0MTA2NDEyMTQ5MTQyNjU4NzREQ0I3NTI5IiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjcyYjA0NDNmLWQ1YWQtNTE0NC04NjI2LWMzNTYwMjI0OTE2MiIgeG1wTU06T3JpZ2luYWxEb2N1bWVudElEPSJBM0ZDNUJDNDEwNjQxMjE0OTE0MjY1ODc0RENCNzUyOSIgeG1wOkNyZWF0ZURhdGU9IjIwMjItMDQtMThUMTM6MDI6NTQrMDU6MzAiIHhtcDpNb2RpZnlEYXRlPSIyMDIyLTA0LTE4VDEzOjA3OjI3KzA1OjMwIiB4bXA6TWV0YWRhdGFEYXRlPSIyMDIyLTA0LTE4VDEzOjA3OjI3KzA1OjMwIj4gPGRjOmNyZWF0b3I+IDxyZGY6U2VxPiA8cmRmOmxpPlBlM2NoZWNrPC9yZGY6bGk+IDwvcmRmOlNlcT4gPC9kYzpjcmVhdG9yPiA8ZGM6ZGVzY3JpcHRpb24+IDxyZGY6QWx0PiA8cmRmOmxpIHhtbDpsYW5nPSJ4LWRlZmF1bHQiPk5vIGltYWdlIGF2YWlsYWJsZSBzaWduLiBJbnRlcm5ldCB3ZWIgaWNvbiB0byBpbmRpY2F0ZSB0aGUgYWJzZW5jZSBvZiBpbWFnZSB1bnRpbCBpdCB3aWxsIGJlIGRvd25sb2FkZWQuPC9yZGY6bGk+IDwvcmRmOkFsdD4gPC9kYzpkZXNjcmlwdGlvbj4gPHBsdXM6TGljZW5zb3I+IDxyZGY6U2VxPiA8cmRmOmxpIHBsdXM6TGljZW5zb3JVUkw9Imh0dHBzOi8vd3d3LmlzdG9ja3Bob3RvLmNvbS9waG90by9saWNlbnNlLWdtOTIyOTYyMzU0LT91dG1fbWVkaXVtPW9yZ2FuaWMmYW1wO3V0bV9zb3VyY2U9Z29vZ2xlJmFtcDt1dG1fY2FtcGFpZ249aXB0Y3VybCIvPiA8L3JkZjpTZXE+IDwvcGx1czpMaWNlbnNvcj4gPHhtcE1NOkhpc3Rvcnk+IDxyZGY6U2VxPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0ic2F2ZWQiIHN0RXZ0Omluc3RhbmNlSUQ9InhtcC5paWQ6NTkzNWYwOTctYzg3Ni03YTRmLWE1NTYtMzcyOTUwNzdjODc2IiBzdEV2dDp3aGVuPSIyMDIyLTA0LTE4VDEzOjA1OjQ5KzA1OjMwIiBzdEV2dDpzb2Z0d2FyZUFnZW50PSJBZG9iZSBQaG90b3Nob3AgQ0MgMjAxNyAoV2luZG93cykiIHN0RXZ0OmNoYW5nZWQ9Ii8iLz4gPHJkZjpsaSBzdEV2dDphY3Rpb249InNhdmVkIiBzdEV2dDppbnN0YW5jZUlEPSJ4bXAuaWlkOjcyYjA0NDNmLWQ1YWQtNTE0NC04NjI2LWMzNTYwMjI0OTE2MiIgc3RFdnQ6d2hlbj0iMjAyMi0wNC0xOFQxMzowNzoyNyswNTozMCIgc3RFdnQ6c29mdHdhcmVBZ2VudD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTcgKFdpbmRvd3MpIiBzdEV2dDpjaGFuZ2VkPSIvIi8+IDwvcmRmOlNlcT4gPC94bXBNTTpIaXN0b3J5PiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8P3hwYWNrZXQgZW5kPSJ3Ij8+/+4AIUFkb2JlAGRAAAAAAQMAEAMCAwYAAAAAAAAAAAAAAAD/2wCEAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQECAgICAgICAgICAgMDAwMDAwMDAwMBAQEBAQEBAQEBAQICAQICAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDA//CABEIAGQAZAMBEQACEQEDEQH/xACeAAEAAQUBAQEAAAAAAAAAAAAACQQGBwgKBQMCAQEAAAAAAAAAAAAAAAAAAAAAEAABAwQCAQMFAQAAAAAAAAAGBQcIAgMECQAgAUBwODATFTcYJxEAAQUBAAAEBAIGBwkAAAAAAwECBAUGBxESEwgAIRQVICIQMSMWtndAYTJDldY4MEFCMyQ0JhcJEgEAAAAAAAAAAAAAAAAAAABw/9oADAMBAQIRAxEAAADv4AAAAAAABj4tU5wzak+xIIbwHqAAEZpyzn4JKDPpFKZlLzOuoAAhoOd4lXNdzVYnaIADOJ2jAAENBzvE2hCOfQloI5i4ztGAAIaDneN/TPBqsSRkBZnc7RgADTg5tDzjOpm00lKckAOiMAAxoesXqWmXYAAAAR+mlRukYbMZntnjF1EvZXAApz5lCVR8ygNeDYUuUAAxyaJGSSzDDRehRmQyRcAAxaY1POKwswry5T3jYIAAAAAAAH//2gAIAQIAAQUA9qf/2gAIAQMAAQUA9qf/2gAIAQEAAQUA9Aqu01SDnkcjGMGh6NJ5GJ3StRw9QNCfrBmBigTFDuwECXiJGXEQjwOu1R7zZnY51I6TXXUmomHSxWsCTL1ohNpfdzCT3mZly2ZJ5BI8JfLa69nmMWSk313S/pfmrePQialkqZ1u9KEqEjg9AFlpzZH2mRbqtZmNdi78oeu6X9L8iXi55Jqbs3bV6zzTWnqt+Sb5KCQrvrF35Q9d0vn/ABjmvOWyVF105N6uDjFXwfXlM47VjkhbHVrGuza8WLUXflB1nNF/IlaxytBuZaKo/wAXzD4zoZtGj/YKHX3NliXnQ7miqKP8XzC5AfXS8lp4epK8LcB7iIjhiJGZcGzceLVH6MmmyT3mkDbeJxVC5HdRQEiTh4XmSyvuMMVgoTKh37WG5r4GKRcHXoUS4uelLpUaUzpViYteT+OT/uIA2OiibUkJNVflMRM2zki4jmLbtR2WnfIlsMDya71dwvvALajc3zmpIKZOGFrAB5AXndLGbfApZyGqU4bmuzJW6/twkdWP0yjR0nL6vG0o69gIORYDUvEriQGYQGExNb4FU0eDwCLYtqGYoh3EGIrRD9ppGFymhveg/9oACAECAgY/ACn/2gAIAQMCBj8AKf/aAAgBAQEGPwD+gSKq86bz6mtIb1FLrbXZ5yunxSNVWuHIhzLIMgD2uaqKjmoqKnxe6OX1nnMqJQU1ndSotdt8vNsJMerhGnGjwIYLVxpc0wwK0QmIriEVGoiqqfHdeje+P" +
        // "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";

        public string? Base64ImageDocument { get; set; } = "";

    }

    public class Item : ItemSimple
    {

        public int LiNo { get; set; }

        public CodeBaseResponse ItemType { get; set; } // Added
        public string EAN { get; set; }  // Added

        public string ItemShortName { get; set; }  // Added
        public string Description { get; set; } // Added
        public UnitResponse ItemUnit { get; set; }  // Added
        public UnitResponse ServiceUnit { get; set; }  // Added
        public string Remarks { get; set; }  // Added
        public decimal CostPrice { get; set; }  // Added
        public decimal SalesPrice { get; set; } // Added
        public decimal OptionalSalesPrice { get; set; } // Added
        public CodeBaseResponse ItemCategory1 { get; set; }
        public CodeBaseResponse ItemCategory2 { get; set; }
        public CodeBaseResponse ItemCategory3 { get; set; }
        public CodeBaseResponse ItemPriceCategory { get; set; }
        public CodeBaseResponse ItemProperty1 { get; set; }
        public CodeBaseResponse ItemProperty2 { get; set; }
        public CodeBaseResponse ItemProperty3 { get; set; }
        public CodeBaseResponse ItemProperty4 { get; set; }
        public ItemResponse ParentItem { get; set; }
        public CodeBaseResponse Brand { get; set; }

        public decimal SupplierWarranty { get; set; }
        public decimal CustomerWarranty { get; set; }
        public string ItemComboTitle
        {
            get
            {
                return ItemCode + " - " + ItemName;
            }
        }
        public string PartNumber { get; set; }
        public CodeBaseResponse Model { get; set; }
        public bool IsSerialNumber { get; set; }
        public decimal ReOrderLevel { get; set; }
        public decimal ReOrderQuantity { get; set; }
    }


     
    public class ItemExtended : Item
    {

        public decimal DefaultDiscountPercentage { get; set; }
        public CodeBaseResponse ItemCategory4 { get; set; }
        public CodeBaseResponse ItemCategory5 { get; set; }
        public CodeBaseResponse ItemCategory6 { get; set; }
        public CodeBaseResponse ItemCategory7 { get; set; }
        public CodeBaseResponse ItemCategory8 { get; set; }
        public CodeBaseResponse ItemCategory9 { get; set; }
        public CodeBaseResponse ItemCategory10 { get; set; }
        public CodeBaseResponse ItemCategory11 { get; set; }
        public CodeBaseResponse ItemCategory12 { get; set; }

        public bool IsMain { get; set; }
        public byte Level { get; set; }

        public CodeBaseResponse AccessLevel { get; set; }
        public CodeBaseResponse ConfidentialLevel { get; set; }

        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }





        public decimal Warrenty { get; set; }

        public decimal AverageWarrenty { get; set; }

        public CodeBaseResponse BussienssUnit { get; set; }
        public Account IncomeAccount { get; set; }
        public Account ExpenseAccount { get; set; }
        public Account AssetAccount { get; set; }
        public Account DepreiciationAccount { get; set; }
        public Account CostAccount { get; set; }
        public Account CostManufactureAccount { get; set; }
        public decimal DepriciationPercentage { get; set; }

        public string OwnPartNumber { get; set; }
        public UnitResponse WarrentyUnit { get; set; }
        public Address Address { get; set; }

        public UnitResponse LooseUnit { get; set; }
        public UnitResponse BulkUnit { get; set; }
        public UnitResponse StandardUnit { get; set; }
        public UnitResponse InernalUnit { get; set; }

        public decimal AnalysisQuantity { get; set; }

        public decimal NumberOfCondenseStates { get; set; }

        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }

        public bool IsDiscountinued { get; set; }

        public bool AllowTransactionRateChange { get; set; }

        public bool AllowZeroPrice { get; set; }

        public decimal MinimumQuantity { get; set; }
        public decimal MaximumQuantity { get; set; }

        public CodeBaseResponse ItemAccountCategory { get; set; }
        public bool IsSubstitute { get; set; }

        public bool IsItem1 { get; set; }
        public bool IsItem2 { get; set; }
        public bool IsItem3 { get; set; }
        public bool IsItem4 { get; set; }
        public bool IsGeneric { get; set; }
        public bool AllowForTransaction { get; set; }

















    }

    public class RateRetrivalModel : BaseModel
    {
        public long ObjectKey { get; set; } = 1;

        public long ItemKey { get; set; } = 1;
        public DateTime EffectiveDate { get; set; }
        public long LocationKey { get; set; } = 1;
        public long TransactionTypeKey { get; set; } = 1;
        public long BussienssUnitKey { get; set; } = 1;
        public long ProjectKey { get; set; } = 1;

        public long AddressKey { get; set; } = 1;

        public long AccountKey { get; set; } = 1;
        public long PayementTermKey { get; set; } = 1;
        public long Code1Key { get; set; } = 1;
        public long Code2Key { get; set; } = 1;

        public decimal Rate { get; set; }
        public string ConditionCode { get; set; } = "";
    }

    public class ItemRateResponse : BaseEntity
    {
        public decimal TransactionRate { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal ItemTaxType1 { get; set; }
        public decimal ItemTaxType2 { get; set; }
        public decimal ItemTaxType3 { get; set; }
        public decimal ItemTaxType4 { get; set; }
        public decimal ItemTaxType5 { get; set; }
        public int UnitKey { get; set; }

        public string AddressTaxType1 { get; set; } = "";

        public ItemSimple RateItem { get; set; } = new ItemSimple();

        public decimal Rate { get; set; }

        public decimal SplitLength { get; set; }
        public decimal MarkUpPercentage { get; set; }
        public decimal MinimumSalesPrice { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }




    }
}
