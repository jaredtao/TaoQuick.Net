import QtQml 2.0
import QtQuick 2.0
import QtQuick.Controls 2.0

import TaoQuick 1.0
ApplicationWindow {
	width: 800
	height: 600
	title: "Hello qmlNet"
	visible: true

	Row {
		anchors.centerIn: parent
		spacing: 10
		CusButton_Blue {
			text: "B1"
			width: 120
			height: 50
		}
		CusButton_Blue {
			text: "B2"
			width: 120
			height: 50
		}
		CusButton_Blue {
			text: "B3"
			width: 120
			height: 50
		}
	}
}