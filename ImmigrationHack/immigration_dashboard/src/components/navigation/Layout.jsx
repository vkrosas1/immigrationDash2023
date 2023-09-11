import { BrowserRouter as Router, Route, Redirect, Switch } from 'react-router-dom';
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
                    <Switch class="block">
                        <Route exact path="/home" render={() => (
                            <HomeController {...props} />
                        )} />
                        <Route exact path="/documents" render={() => (
                            <DocumentsController {...props} />
                        )} />
                        <Route exact path="/files" render={() => (
                            <FilesController {...props} />
                        )} />
                        <Route exact path="/settings" render={() => (
                            <SettingsController {...props} />
                        )} />
                        <Redirect to="/home" />
                    </Switch>
                </div>
            </div>
        </Router>
    );
}

export default Layout;