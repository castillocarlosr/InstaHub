import * as React from 'react';
import { RouteComponentProps } from 'react-router';

import { Chat } from './home/Chat';
import { Users } from './home/Users';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, world!</h1>
            <p>We are Team Fix-It-Felix AKA InstaHub</p>
            <div className='col-sm-3'>
                <Users />
            </div>
            <div className='col-sm-9'>
                <Chat />
            </div>
      </div>
    );
  }
}
