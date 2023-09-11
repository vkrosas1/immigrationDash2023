import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomeController from '../home/HomeController';
import DocumentsController from '../documents/DocumentsController';
import FilesController from '../files/FilesController';
import SettingsController from '../settings/SettingsController';
import Header from './Header';

function Layout(props) {

    return (
        <Router>
            <div className="App">
                <div className="container">
                    <Header class="block" {...props} />
                    <Routes class="block">
                        <Route exact path="/home" element=<HomeController {...props} />></Route>
                        <Route exact path="/documents" element=<DocumentsController {...props} />></Route>
                        <Route exact path="/files" element=<FilesController {...props} />></Route>
                        <Route exact path="/settings" element=<SettingsController {...props} />></Route>
                        <Route to="/home" />
                    </Routes>
                </div>
            </div>
        </Router>
    );
}

export default Layout;