﻿using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000C1 RID: 193
	internal enum WindowMessage
	{
		// Token: 0x0400058A RID: 1418
		NULL,
		// Token: 0x0400058B RID: 1419
		CREATE,
		// Token: 0x0400058C RID: 1420
		DESTROY,
		// Token: 0x0400058D RID: 1421
		MOVE,
		// Token: 0x0400058E RID: 1422
		SIZE = 5,
		// Token: 0x0400058F RID: 1423
		ACTIVATE,
		// Token: 0x04000590 RID: 1424
		SETFOCUS,
		// Token: 0x04000591 RID: 1425
		KILLFOCUS,
		// Token: 0x04000592 RID: 1426
		ENABLE = 10,
		// Token: 0x04000593 RID: 1427
		SETREDRAW,
		// Token: 0x04000594 RID: 1428
		SETTEXT,
		// Token: 0x04000595 RID: 1429
		GETTEXT,
		// Token: 0x04000596 RID: 1430
		GETTEXTLENGTH,
		// Token: 0x04000597 RID: 1431
		PAINT,
		// Token: 0x04000598 RID: 1432
		CLOSE,
		// Token: 0x04000599 RID: 1433
		QUERYENDSESSION,
		// Token: 0x0400059A RID: 1434
		QUIT,
		// Token: 0x0400059B RID: 1435
		QUERYOPEN,
		// Token: 0x0400059C RID: 1436
		ERASEBKGND,
		// Token: 0x0400059D RID: 1437
		SYSCOLORCHANGE,
		// Token: 0x0400059E RID: 1438
		ENDSESSION,
		// Token: 0x0400059F RID: 1439
		SHOWWINDOW = 24,
		// Token: 0x040005A0 RID: 1440
		CTLCOLOR,
		// Token: 0x040005A1 RID: 1441
		WININICHANGE,
		// Token: 0x040005A2 RID: 1442
		SETTINGCHANGE = 26,
		// Token: 0x040005A3 RID: 1443
		DEVMODECHANGE,
		// Token: 0x040005A4 RID: 1444
		ACTIVATEAPP,
		// Token: 0x040005A5 RID: 1445
		FONTCHANGE,
		// Token: 0x040005A6 RID: 1446
		TIMECHANGE,
		// Token: 0x040005A7 RID: 1447
		CANCELMODE,
		// Token: 0x040005A8 RID: 1448
		SETCURSOR,
		// Token: 0x040005A9 RID: 1449
		MOUSEACTIVATE,
		// Token: 0x040005AA RID: 1450
		CHILDACTIVATE,
		// Token: 0x040005AB RID: 1451
		QUEUESYNC,
		// Token: 0x040005AC RID: 1452
		GETMINMAXINFO,
		// Token: 0x040005AD RID: 1453
		PAINTICON = 38,
		// Token: 0x040005AE RID: 1454
		ICONERASEBKGND,
		// Token: 0x040005AF RID: 1455
		NEXTDLGCTL,
		// Token: 0x040005B0 RID: 1456
		SPOOLERSTATUS = 42,
		// Token: 0x040005B1 RID: 1457
		DRAWITEM,
		// Token: 0x040005B2 RID: 1458
		MEASUREITEM,
		// Token: 0x040005B3 RID: 1459
		DELETEITEM,
		// Token: 0x040005B4 RID: 1460
		VKEYTOITEM,
		// Token: 0x040005B5 RID: 1461
		CHARTOITEM,
		// Token: 0x040005B6 RID: 1462
		SETFONT,
		// Token: 0x040005B7 RID: 1463
		GETFONT,
		// Token: 0x040005B8 RID: 1464
		SETHOTKEY,
		// Token: 0x040005B9 RID: 1465
		GETHOTKEY,
		// Token: 0x040005BA RID: 1466
		QUERYDRAGICON = 55,
		// Token: 0x040005BB RID: 1467
		COMPAREITEM = 57,
		// Token: 0x040005BC RID: 1468
		GETOBJECT = 61,
		// Token: 0x040005BD RID: 1469
		COMPACTING = 65,
		// Token: 0x040005BE RID: 1470
		COMMNOTIFY = 68,
		// Token: 0x040005BF RID: 1471
		WINDOWPOSCHANGING = 70,
		// Token: 0x040005C0 RID: 1472
		WINDOWPOSCHANGED,
		// Token: 0x040005C1 RID: 1473
		POWER,
		// Token: 0x040005C2 RID: 1474
		COPYDATA = 74,
		// Token: 0x040005C3 RID: 1475
		CANCELJOURNAL,
		// Token: 0x040005C4 RID: 1476
		NOTIFY = 78,
		// Token: 0x040005C5 RID: 1477
		INPUTLANGCHANGEREQUEST = 80,
		// Token: 0x040005C6 RID: 1478
		INPUTLANGCHANGE,
		// Token: 0x040005C7 RID: 1479
		TCARD,
		// Token: 0x040005C8 RID: 1480
		HELP,
		// Token: 0x040005C9 RID: 1481
		USERCHANGED,
		// Token: 0x040005CA RID: 1482
		NOTIFYFORMAT,
		// Token: 0x040005CB RID: 1483
		CONTEXTMENU = 123,
		// Token: 0x040005CC RID: 1484
		STYLECHANGING,
		// Token: 0x040005CD RID: 1485
		STYLECHANGED,
		// Token: 0x040005CE RID: 1486
		DISPLAYCHANGE,
		// Token: 0x040005CF RID: 1487
		GETICON,
		// Token: 0x040005D0 RID: 1488
		SETICON,
		// Token: 0x040005D1 RID: 1489
		NCCREATE,
		// Token: 0x040005D2 RID: 1490
		NCDESTROY,
		// Token: 0x040005D3 RID: 1491
		NCCALCSIZE,
		// Token: 0x040005D4 RID: 1492
		NCHITTEST,
		// Token: 0x040005D5 RID: 1493
		NCPAINT,
		// Token: 0x040005D6 RID: 1494
		NCACTIVATE,
		// Token: 0x040005D7 RID: 1495
		GETDLGCODE,
		// Token: 0x040005D8 RID: 1496
		SYNCPAINT,
		// Token: 0x040005D9 RID: 1497
		NCMOUSEMOVE = 160,
		// Token: 0x040005DA RID: 1498
		NCLBUTTONDOWN,
		// Token: 0x040005DB RID: 1499
		NCLBUTTONUP,
		// Token: 0x040005DC RID: 1500
		NCLBUTTONDBLCLK,
		// Token: 0x040005DD RID: 1501
		NCRBUTTONDOWN,
		// Token: 0x040005DE RID: 1502
		NCRBUTTONUP,
		// Token: 0x040005DF RID: 1503
		NCRBUTTONDBLCLK,
		// Token: 0x040005E0 RID: 1504
		NCMBUTTONDOWN,
		// Token: 0x040005E1 RID: 1505
		NCMBUTTONUP,
		// Token: 0x040005E2 RID: 1506
		NCMBUTTONDBLCLK,
		// Token: 0x040005E3 RID: 1507
		NCXBUTTONDOWN = 171,
		// Token: 0x040005E4 RID: 1508
		NCXBUTTONUP,
		// Token: 0x040005E5 RID: 1509
		NCXBUTTONDBLCLK,
		// Token: 0x040005E6 RID: 1510
		INPUT = 255,
		// Token: 0x040005E7 RID: 1511
		KEYDOWN,
		// Token: 0x040005E8 RID: 1512
		KEYFIRST = 256,
		// Token: 0x040005E9 RID: 1513
		KEYUP,
		// Token: 0x040005EA RID: 1514
		CHAR,
		// Token: 0x040005EB RID: 1515
		DEADCHAR,
		// Token: 0x040005EC RID: 1516
		SYSKEYDOWN,
		// Token: 0x040005ED RID: 1517
		SYSKEYUP,
		// Token: 0x040005EE RID: 1518
		SYSCHAR,
		// Token: 0x040005EF RID: 1519
		SYSDEADCHAR,
		// Token: 0x040005F0 RID: 1520
		KEYLAST,
		// Token: 0x040005F1 RID: 1521
		IME_STARTCOMPOSITION = 269,
		// Token: 0x040005F2 RID: 1522
		IME_ENDCOMPOSITION,
		// Token: 0x040005F3 RID: 1523
		IME_COMPOSITION,
		// Token: 0x040005F4 RID: 1524
		IME_KEYLAST = 271,
		// Token: 0x040005F5 RID: 1525
		INITDIALOG,
		// Token: 0x040005F6 RID: 1526
		COMMAND,
		// Token: 0x040005F7 RID: 1527
		SYSCOMMAND,
		// Token: 0x040005F8 RID: 1528
		TIMER,
		// Token: 0x040005F9 RID: 1529
		HSCROLL,
		// Token: 0x040005FA RID: 1530
		VSCROLL,
		// Token: 0x040005FB RID: 1531
		INITMENU,
		// Token: 0x040005FC RID: 1532
		INITMENUPOPUP,
		// Token: 0x040005FD RID: 1533
		MENUSELECT = 287,
		// Token: 0x040005FE RID: 1534
		MENUCHAR,
		// Token: 0x040005FF RID: 1535
		ENTERIDLE,
		// Token: 0x04000600 RID: 1536
		MENURBUTTONUP,
		// Token: 0x04000601 RID: 1537
		MENUDRAG,
		// Token: 0x04000602 RID: 1538
		MENUGETOBJECT,
		// Token: 0x04000603 RID: 1539
		UNINITMENUPOPUP,
		// Token: 0x04000604 RID: 1540
		MENUCOMMAND,
		// Token: 0x04000605 RID: 1541
		CHANGEUISTATE,
		// Token: 0x04000606 RID: 1542
		UPDATEUISTATE,
		// Token: 0x04000607 RID: 1543
		QUERYUISTATE,
		// Token: 0x04000608 RID: 1544
		CTLCOLORMSGBOX = 306,
		// Token: 0x04000609 RID: 1545
		CTLCOLOREDIT,
		// Token: 0x0400060A RID: 1546
		CTLCOLORLISTBOX,
		// Token: 0x0400060B RID: 1547
		CTLCOLORBTN,
		// Token: 0x0400060C RID: 1548
		CTLCOLORDLG,
		// Token: 0x0400060D RID: 1549
		CTLCOLORSCROLLBAR,
		// Token: 0x0400060E RID: 1550
		CTLCOLORSTATIC,
		// Token: 0x0400060F RID: 1551
		MOUSEMOVE = 512,
		// Token: 0x04000610 RID: 1552
		MOUSEFIRST = 512,
		// Token: 0x04000611 RID: 1553
		LBUTTONDOWN,
		// Token: 0x04000612 RID: 1554
		LBUTTONUP,
		// Token: 0x04000613 RID: 1555
		LBUTTONDBLCLK,
		// Token: 0x04000614 RID: 1556
		RBUTTONDOWN,
		// Token: 0x04000615 RID: 1557
		RBUTTONUP,
		// Token: 0x04000616 RID: 1558
		RBUTTONDBLCLK,
		// Token: 0x04000617 RID: 1559
		MBUTTONDOWN,
		// Token: 0x04000618 RID: 1560
		MBUTTONUP,
		// Token: 0x04000619 RID: 1561
		MBUTTONDBLCLK,
		// Token: 0x0400061A RID: 1562
		MOUSEWHEEL,
		// Token: 0x0400061B RID: 1563
		XBUTTONDOWN,
		// Token: 0x0400061C RID: 1564
		XBUTTONUP,
		// Token: 0x0400061D RID: 1565
		XBUTTONDBLCLK,
		// Token: 0x0400061E RID: 1566
		MOUSEHWHEEL,
		// Token: 0x0400061F RID: 1567
		PARENTNOTIFY = 528,
		// Token: 0x04000620 RID: 1568
		ENTERMENULOOP,
		// Token: 0x04000621 RID: 1569
		EXITMENULOOP,
		// Token: 0x04000622 RID: 1570
		NEXTMENU,
		// Token: 0x04000623 RID: 1571
		SIZING,
		// Token: 0x04000624 RID: 1572
		CAPTURECHANGED,
		// Token: 0x04000625 RID: 1573
		MOVING,
		// Token: 0x04000626 RID: 1574
		DEVICECHANGE = 537,
		// Token: 0x04000627 RID: 1575
		MDICREATE = 544,
		// Token: 0x04000628 RID: 1576
		MDIDESTROY,
		// Token: 0x04000629 RID: 1577
		MDIACTIVATE,
		// Token: 0x0400062A RID: 1578
		MDIRESTORE,
		// Token: 0x0400062B RID: 1579
		MDINEXT,
		// Token: 0x0400062C RID: 1580
		MDIMAXIMIZE,
		// Token: 0x0400062D RID: 1581
		MDITILE,
		// Token: 0x0400062E RID: 1582
		MDICASCADE,
		// Token: 0x0400062F RID: 1583
		MDIICONARRANGE,
		// Token: 0x04000630 RID: 1584
		MDIGETACTIVE,
		// Token: 0x04000631 RID: 1585
		MDISETMENU = 560,
		// Token: 0x04000632 RID: 1586
		ENTERSIZEMOVE,
		// Token: 0x04000633 RID: 1587
		EXITSIZEMOVE,
		// Token: 0x04000634 RID: 1588
		DROPFILES,
		// Token: 0x04000635 RID: 1589
		MDIREFRESHMENU,
		// Token: 0x04000636 RID: 1590
		IME_SETCONTEXT = 641,
		// Token: 0x04000637 RID: 1591
		IME_NOTIFY,
		// Token: 0x04000638 RID: 1592
		IME_CONTROL,
		// Token: 0x04000639 RID: 1593
		IME_COMPOSITIONFULL,
		// Token: 0x0400063A RID: 1594
		IME_SELECT,
		// Token: 0x0400063B RID: 1595
		IME_CHAR,
		// Token: 0x0400063C RID: 1596
		IME_REQUEST = 648,
		// Token: 0x0400063D RID: 1597
		IME_KEYDOWN = 656,
		// Token: 0x0400063E RID: 1598
		IME_KEYUP,
		// Token: 0x0400063F RID: 1599
		NCMOUSEHOVER = 672,
		// Token: 0x04000640 RID: 1600
		MOUSEHOVER,
		// Token: 0x04000641 RID: 1601
		NCMOUSELEAVE,
		// Token: 0x04000642 RID: 1602
		MOUSELEAVE,
		// Token: 0x04000643 RID: 1603
		CUT = 768,
		// Token: 0x04000644 RID: 1604
		COPY,
		// Token: 0x04000645 RID: 1605
		PASTE,
		// Token: 0x04000646 RID: 1606
		CLEAR,
		// Token: 0x04000647 RID: 1607
		UNDO,
		// Token: 0x04000648 RID: 1608
		RENDERFORMAT,
		// Token: 0x04000649 RID: 1609
		RENDERALLFORMATS,
		// Token: 0x0400064A RID: 1610
		DESTROYCLIPBOARD,
		// Token: 0x0400064B RID: 1611
		DRAWCLIPBOARD,
		// Token: 0x0400064C RID: 1612
		PAINTCLIPBOARD,
		// Token: 0x0400064D RID: 1613
		VSCROLLCLIPBOARD,
		// Token: 0x0400064E RID: 1614
		SIZECLIPBOARD,
		// Token: 0x0400064F RID: 1615
		ASKCBFORMATNAME,
		// Token: 0x04000650 RID: 1616
		CHANGECBCHAIN,
		// Token: 0x04000651 RID: 1617
		HSCROLLCLIPBOARD,
		// Token: 0x04000652 RID: 1618
		QUERYNEWPALETTE,
		// Token: 0x04000653 RID: 1619
		PALETTEISCHANGING,
		// Token: 0x04000654 RID: 1620
		PALETTECHANGED,
		// Token: 0x04000655 RID: 1621
		HOTKEY,
		// Token: 0x04000656 RID: 1622
		PRINT = 791,
		// Token: 0x04000657 RID: 1623
		PRINTCLIENT,
		// Token: 0x04000658 RID: 1624
		HANDHELDFIRST = 856,
		// Token: 0x04000659 RID: 1625
		HANDHELDLAST = 863,
		// Token: 0x0400065A RID: 1626
		AFXFIRST,
		// Token: 0x0400065B RID: 1627
		AFXLAST = 895,
		// Token: 0x0400065C RID: 1628
		PENWINFIRST,
		// Token: 0x0400065D RID: 1629
		PENWINLAST = 911,
		// Token: 0x0400065E RID: 1630
		APP = 32768,
		// Token: 0x0400065F RID: 1631
		USER = 1024,
		// Token: 0x04000660 RID: 1632
		MOUSE_ENTER,
		// Token: 0x04000661 RID: 1633
		ASYNC_MESSAGE = 1027,
		// Token: 0x04000662 RID: 1634
		REFLECT = 8192,
		// Token: 0x04000663 RID: 1635
		CLOSE_INTERNAL,
		// Token: 0x04000664 RID: 1636
		BALLOONSHOW = 1026,
		// Token: 0x04000665 RID: 1637
		BALLOONHIDE,
		// Token: 0x04000666 RID: 1638
		BALLOONTIMEOUT,
		// Token: 0x04000667 RID: 1639
		BALLOONUSERCLICK
	}
}
