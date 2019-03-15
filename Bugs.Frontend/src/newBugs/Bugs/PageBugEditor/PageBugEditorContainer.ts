import {AnyAction, Dispatch} from "redux";
import {connect} from "react-redux";
import {match, withRouter} from "react-router";

import {IReducers} from "@reducer";
import {BugDTO} from "../../../models/bugs/BugDTO";
import {PageBugEditor, IBugEditorProps, IBugEditorCallProps} from "./PageBugEditor";

const mapStateToProps = (state: IReducers, ownProps: IBugEditorProps): IBugEditorProps => {
    return {
        apiUrl: ownProps.apiUrl,
        bug: state.BugEditorStore.bug
    };
};

type OwnCallProps = IBugEditorCallProps & {
    match: match<any>
};

const mapDispatchToProps = (dispatch: Dispatch<AnyAction>, ownProps: OwnCallProps): IBugEditorCallProps => {
        return {
            load: () => {ownProps.match.params.id},
            renderBugList: () => {},
            save: (bug: BugDTO) => {}
        };
    };

const connector = connect(
    mapStateToProps,
    mapDispatchToProps
)(PageBugEditor);

const PageBugEditorContainer = withRouter(connector);
export default PageBugEditorContainer;