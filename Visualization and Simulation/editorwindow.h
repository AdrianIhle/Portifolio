#ifndef EDITORWINDOW_H
#define EDITORWINDOW_H

#include <QMainWindow>
#include<QKeyEvent>

namespace Ui {
class EditorWindow;
}

class EditorWindow : public QMainWindow
{
    Q_OBJECT

public:
	explicit EditorWindow(QWidget *parent = 0);
    ~EditorWindow();

    void setColor();

private slots:

    void on_actionQuit_triggered();

    void on_actionLoad_Mesh_triggered();

    void on_ColorButton_released();

public slots:
	void hierarchyInit(std::vector<class GameObject*> &mGeometry);

private:
    Ui::EditorWindow *ui;

};

#endif // EDITORWINDOW_H
