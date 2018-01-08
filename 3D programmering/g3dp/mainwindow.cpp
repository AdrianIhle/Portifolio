#include <QtWidgets>
#include "mainWindow.h"
#include "gamewidget.h"
#include "shaderprogram.h"

MainWindow::MainWindow() : QMainWindow(), scriptFileName(0)
{
    createMenu();

    // Shaderne er her en del av Qt prosjektet, se Resources og Other files
    fragmentShaderFilnavn = new QString(":mine/fragmentshader.glsl");
    vertexShaderFilnavn = new QString(":mine/vertexshader.glsl");

    fragmentShaderEditor = new QPlainTextEdit();
    // Dette gir en uønsket ekstra, liten scrollbar øverst til venstre:
    // QScrollBar* fragmentVScrollBar = new QScrollBar(Qt::Vertical, fragmentShaderEditor);
    QScrollBar* fragmentVScrollBar = new QScrollBar(Qt::Vertical);
    fragmentShaderEditor->addScrollBarWidget(fragmentVScrollBar, Qt::AlignRight);

    QString tekst;
    loadFile(*fragmentShaderFilnavn, tekst);
    fragmentShaderEditor->setPlainText(tekst);

    vertexShaderEditor = new QPlainTextEdit();
    QScrollBar* vertexVScrollBar = new QScrollBar(Qt::Vertical);
    vertexShaderEditor->addScrollBarWidget(vertexVScrollBar, Qt::AlignRight);
    loadFile(*vertexShaderFilnavn, tekst);
    vertexShaderEditor->setPlainText(tekst);

    scriptFileEditor = new QPlainTextEdit();
    QScrollBar* scriptVScrollBar = new QScrollBar(Qt::Vertical);
    scriptFileEditor->addScrollBarWidget(scriptVScrollBar, Qt::AlignRight);

    glWidget = new GameWidget(this);

    QLayout* knapper = buttonLayout();

    m_hBoxLayout = new QHBoxLayout();
    m_hBoxLayout->addLayout(knapper);
    m_hBoxLayout->addWidget(glWidget);

    QVBoxLayout *mainLayout = new QVBoxLayout;

    setMenuWidget(menuBar);

    //mainLayout->addWidget(fragmentShaderEditor);
    //mainLayout->addWidget(vertexShaderEditor);
    mainLayout->addWidget(scriptFileEditor);
    mainLayout->addLayout(m_hBoxLayout);

    QWidget* mainWidget = new QWidget();
    mainWidget->setLayout(mainLayout);
    setCentralWidget(mainWidget);

    setWindowTitle(tr("Basic OpenGL"));
    statusBar()->showMessage("Interaktiv shadervisualisering");
//this->resize(1024, 768);
    kobleSignalsAndSlots();
}

MainWindow::~MainWindow()
{
    delete glWidget;
}

void MainWindow::close()
{
    QMainWindow::close();
}

void MainWindow::kobleSignalsAndSlots()
{
    /// QPushButton klassen har signalet clicked()
    /// Kobler alle knappenes clicked() til samme slot klikket() i glWidget
    for (int i=0; i<NumButtons; i++)
        connect(buttons[i],SIGNAL(clicked()), glWidget, SLOT(klikket()));

    /// QAction klassen har signalet triggered()
    /// Kobler disse til respektive slot for å lese/skrive shaderkode fra fil
/*    connect(openFragmentAction, SIGNAL(triggered()), this, SLOT(openFragmentShader()));
    connect(openVertexAction, SIGNAL(triggered()), this, SLOT(openVertexShader()));
    connect(saveFragmentAction, SIGNAL(triggered()), this, SLOT(saveFragmentShader()));
    connect(saveVertexAction, SIGNAL(triggered()), this, SLOT(saveVertexShader()));
    //connect(saveVertexAction, SIGNAL(triggered()), glWidget, SLOT(redigert()));
    // 150910
    connect(fragmentShaderEditor, SIGNAL(textChanged()), glWidget, SLOT(redigert()));
    connect(vertexShaderEditor, SIGNAL(textChanged()), glWidget, SLOT(redigert()));
*/
    connect(openScriptFileAction, SIGNAL(triggered()), this, SLOT(openScriptFile()));
    connect(saveScriptFileAction, SIGNAL(triggered()), this, SLOT(saveScriptFile()));
    // close() er et slot i QWidget
    // For sikrere exit: Angi som eget slot her, og reimplementer med QWidget::close()
    connect(exitAction, SIGNAL(triggered()), this, SLOT(close()));
}

QString MainWindow::hentFragmentShaderFilnavn() const { return *fragmentShaderFilnavn; }
QString MainWindow::hentVertexShaderFilnavn() const  { return *vertexShaderFilnavn; }
QString MainWindow::hentFragmentShaderKode() const { return fragmentShaderEditor->toPlainText(); }
QString MainWindow::hentVertexShaderKode() const { return vertexShaderEditor->toPlainText() ; }

/// Lager et button layout med navn på knapper for bruk i glWidget slot
QLayout* MainWindow::buttonLayout()
{
    QGridLayout* gridLayout = new QGridLayout();
    for (int i = 0; i < 6; ++i)
    {
        QString qs(tr("%1").arg(i + 1));
        buttons[i] = new QPushButton(qs);
        buttons[i]->setFixedWidth(30);
        buttons[i]->setObjectName(qs);
    }

    buttons[0] = new QPushButton("start");
    buttons[0]->setObjectName("start");

    buttons[1] = new QPushButton("terning");
    buttons[1]->setObjectName("terning");

    buttons[2] = new QPushButton("hjul");
    buttons[2]->setObjectName("hjul");

    buttons[3] = new QPushButton("ball");
    buttons[3]->setObjectName("ball");

    buttons[4] = new QPushButton("Tetraeder");
    buttons[4]->setObjectName("Tetraeder");

    buttons[5] = new QPushButton("clear");
    buttons[5]->setObjectName("clear");




    for (int i = 6; i < NumButtons; ++i)
    {
        QString qs(tr("%1").arg(i -5));
        // Endret for å vise fleksibilitet med QAbstractButton pekere
        buttons[i] = new QCheckBox(qs);
        buttons[i]->setObjectName(qs);

    }
    gridLayout->addWidget(buttons[0], 0, 1);
    gridLayout->addWidget(buttons[1], 1, 0);
    gridLayout->addWidget(buttons[2], 1, 1);
    gridLayout->addWidget(buttons[3], 1, 2);
    gridLayout->addWidget(buttons[4], 2, 1);
    gridLayout->addWidget(buttons[5], 2, 2);
    gridLayout->addWidget(buttons[6], 3, 1);
    gridLayout->addWidget(buttons[7], 3, 2);
    gridLayout->addWidget(buttons[8], 4, 1);
    for (int i=5; i<NumButtons; i++)
         gridLayout->addWidget(buttons[i], i-3, 0, 3, 0);
    return gridLayout;
}

void MainWindow::createMenu()
{
    menuBar = new QMenuBar;

    fileMenu = new QMenu(tr("&File"), this);
//    openFragmentAction = fileMenu->addAction(tr("Open F&ragment..."));
//    openVertexAction = fileMenu->addAction(tr("Open &Vertex..."));
    openScriptFileAction = fileMenu->addAction(tr("Open S&criptfile..."));
//    saveFragmentAction = fileMenu->addAction(tr("Save Fragment..."));
//    saveVertexAction = fileMenu->addAction(tr("Save Vertex..."));
    saveScriptFileAction = fileMenu->addAction(tr("Save Scriptfile..."));
    menuBar->addSeparator();
    exitAction = fileMenu->addAction(tr("E&xit"));
    menuBar->addMenu(fileMenu);
}

void MainWindow::openFragmentShader()
{
    qDebug() << "frag";
    QString filnavn = QFileDialog::getOpenFileName(this);
     if (!filnavn.isEmpty())
     {
         QString tekst;
         loadFile(filnavn, tekst);
         fragmentShaderEditor->setPlainText(tekst);
     }

}

void MainWindow::openVertexShader()
{
    QString filnavn = QFileDialog::getOpenFileName(this);
    if (!filnavn.isEmpty())
    {
        QString tekst;
        loadFile(filnavn, tekst);
        vertexShaderEditor->setPlainText(tekst);
    }
}

void MainWindow::openScriptFile()
{
    QString filnavn = QFileDialog::getOpenFileName(this);
    if (!filnavn.isEmpty())
    {
        QString tekst;
        loadFile(filnavn, tekst);
        scriptFileEditor->setPlainText(tekst);
    }

}

void MainWindow::saveFragmentShader()
{
    qDebug() << "save fragment";
    const QString filnavn = *fragmentShaderFilnavn;
    QString tekst = fragmentShaderEditor->toPlainText();
    saveFile(filnavn, tekst);
}

void MainWindow::saveVertexShader()
{
    qDebug() << "save vertex";
    const QString filnavn = *vertexShaderFilnavn;
    QString tekst = vertexShaderEditor->toPlainText();
    saveFile(filnavn, tekst);
}

void MainWindow::saveScriptFile()
{
    qDebug() << "save scriptfile";
    if (scriptFileName == 0)
    {
        QString filnavn = QFileDialog::getSaveFileName(this);
        if (!filnavn.isEmpty())
        {
            QString tekst = scriptFileEditor->toPlainText();
            saveFile(filnavn, tekst);
        }
    }
    else
    {
        QString tekst = scriptFileEditor->toPlainText();
        saveFile(*scriptFileName, tekst);
    }

}
bool MainWindow::loadFile(const QString& filnavn, QString& tekst)
{
    QFile fil(filnavn);
    if (!fil.open(QFile::ReadOnly | QFile::Text)) {
        QMessageBox::warning(this, tr("App"), tr("kan ikke lese %1:\n%2").arg(filnavn).arg(fil.errorString()));
        return false;
    }
    QTextStream inn(&fil);

    tekst = inn.readAll();
    //tekst = inn.readLine();
    return true;
}

bool MainWindow::saveFile(const QString& filnavn, QString& tekst)
{
    QFile fil(filnavn);
    if (!fil.open(QFile::WriteOnly | QFile::Text))
    {
        QMessageBox::warning(this, tr("ShaderApp"), tr("Kan ikke skrive %1:\n%2.").arg(filnavn).arg(fil.errorString()));
        return false;
    }
    QTextStream ut(&fil);
    ut << tekst;
    return true;
}



