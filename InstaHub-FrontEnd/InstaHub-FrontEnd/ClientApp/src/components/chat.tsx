import * as React from 'react';
import * as moment from 'moment';

interface ChatState {
    messages: ChatMessage[];
    currentMessage: string;
}
interface ChatMessage {
    id: number;
    date: Date;
    message: string;
    sender: string;
}
export class Chat extends React.Component<{}, ChatState> {
    public render() {
        return <div className='panel panel-default'>
            <div className='panel-body panel-chat'
                ref={this.handlePanelRef}>
                <ul>
                    {this.state.messages.map(message =>
                        <li key={message.id}><strong>{message.sender} </strong>
                            ({moment(message.date).format('HH:mm:ss')})<br />
                            {message.message}</li>
                    )}
                </ul>
            </div>
            <div className='panel-footer'>
                <form className='form-inline' onSubmit={this.onSubmit}>
                    <label className='sr-only' htmlFor='msg'>Message</label>
                    <div className='input-group col-md-12'>
                        <button className='chat-button input-group-addon'>:-)</button>
                        <input type='text' value={this.state.currentMessage}
                            onChange={this.handleMessageChange}
                            className='form-control'
                            id='msg'
                            placeholder='Your message'
                            ref={this.handleMessageRef} />
                        <button className='chat-button input-group-addon'>Send</button>
                    </div>
                </form>
            </div>
        </div>;
    }
}